using DBHuan.Shopping.Application.Contracts;
using DBHuan.Shopping.Domain;
using DBHuan.Shopping.Domain.Shared;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace DBHuan.Shopping.HttpApi.AuthAttribute
{
    /// <summary>
    /// Customer authorize
    /// </summary>
    /// CreatedBy: dbhuan 05/02/2022
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomerAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public CustomerAuthorizeAttribute()
        {
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // kiểm tra thông tin xác thực từ token

            try
            {
                // lấy token
                bool hasToken = context.HttpContext.Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues authTokens);

                if (!hasToken)
                {
                    throw new DBHuanShoppingException(ErrorInfo.Code.UnAuthorized, ErrorInfo.Message.UnAuthorized, (int)HttpStatusCode.Unauthorized);
                }

                string token = authTokens.FirstOrDefault();
                if (string.IsNullOrEmpty(token))
                {
                    throw new DBHuanShoppingException(ErrorInfo.Code.UnAuthorized, ErrorInfo.Message.UnAuthorized, (int)HttpStatusCode.Unauthorized);
                }

                token = token.Replace("Bearer ", "");

                if (string.IsNullOrEmpty(token))
                {
                    throw new DBHuanShoppingException(ErrorInfo.Code.UnAuthorized, ErrorInfo.Message.UnAuthorized, (int)HttpStatusCode.Unauthorized);
                }

                // kiểm tra token có hợp lệ

                JwtOption jwtOption = context.HttpContext.RequestServices.GetService<IOptions<JwtOption>>().Value;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(jwtOption.Key);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = jwtOption.Issuer
                }, out SecurityToken validatedToken);

                #region Kiểm tra khách hàng có tồn tại

                var jwtToken = (JwtSecurityToken)validatedToken;
                var customerIdStr = jwtToken.Claims.FirstOrDefault(x => x.Type == AuthClaimTypes.Id).Value;
                if (customerIdStr == null)
                    throw new DBHuanShoppingException(ErrorInfo.Code.UnAuthorized, ErrorInfo.Message.UnAuthorized, (int)HttpStatusCode.Unauthorized);

                var customerId = Guid.Parse(customerIdStr.ToString());
                var customerService = context.HttpContext.RequestServices.GetService<ICustomerService>();
                var customer = await customerService.GetAsync(customerId);
                if (customer == null)
                    throw new DBHuanShoppingException(ErrorInfo.Code.UnAuthorized, ErrorInfo.Message.UnAuthorized, (int)HttpStatusCode.Unauthorized);
                context.HttpContext.Items["Customer"] = customer;

                #endregion Kiểm tra khách hàng có tồn tại
            }
            catch (DBHuanShoppingException ex)
            {
                Log.Logger.Debug("CustomerAuthorizeAttribute-Ex: {e}", ex);
                throw;
            }
            catch (Exception ex)
            {
                Log.Logger.Debug("CustomerAuthorizeAttribute-Ex: {e}", ex);

                throw new DBHuanShoppingException(ErrorInfo.Code.InternalServerError, ErrorInfo.Message.InternalServerError, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}