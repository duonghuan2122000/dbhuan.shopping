using DBHuan.Shopping.Domain;
using DBHuan.Shopping.Domain.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using System.Net;

namespace DBHuan.Shopping.HttpApi
{
    /// <summary>
    /// Middleware dùng chung cho toàn ứng dụng
    /// </summary>
    /// CreatedBy: dbhuan 04/02/2022
    public class DBHuanShoppingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreatedBy: dbhuan 04/02/2022
        public DBHuanShoppingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Log.Logger.Debug("DBHuanShoppingMiddleware-Ex: {ex}", ex);
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string code = ErrorInfo.Code.InternalServerError;
            string message = ErrorInfo.Message.InternalServerError;
            Dictionary<string, string>? validationsData = null;

            if (ex is DBHuanShoppingException)
            {
                var mEx = ex as DBHuanShoppingException;
                statusCode = mEx.StatusCode;
                code = mEx.ErrorCode;
                message = mEx.ErrorMessage;
                validationsData = (Dictionary<string, string>?)mEx.ValidationsData;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorInfoRes
            {
                ErrorCode = code,
                ErrorMessage = message,
                ValidationsData = validationsData
            }, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            }));
        }
    }
}