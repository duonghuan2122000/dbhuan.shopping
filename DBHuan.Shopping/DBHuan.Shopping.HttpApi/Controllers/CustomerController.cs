using DBHuan.Shopping.Application.Contracts;
using DBHuan.Shopping.Domain;
using DBHuan.Shopping.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;

namespace DBHuan.Shopping.HttpApi
{
    /// <summary>
    /// Controller chứa các api của customer
    /// </summary>
    /// CreatedBy: dbhuan 05/02/2022
    [Route("customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Khởi tạo

        private readonly ICustomerService _customerService;

        private readonly JwtOption _jwtOption;

        private readonly IValidationService _validationService;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreatedBy: dbhuan 05/02/2022
        public CustomerController(
            ICustomerService customerService,
            IOptions<JwtOption> jwtOption,
            IValidationService validationService
            )
        {
            _customerService = customerService;
            _jwtOption = jwtOption.Value;
            _validationService = validationService;
        }

        #endregion Khởi tạo

        #region Hàm

        /// <summary>
        /// Api xác minh tài khoản khách hàng
        /// </summary>
        /// CreatedBy: dbhuan 14/02/2022
        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate(AuthenticateCustomerReq req)
        {
            _validationService.Validate(req);

            var authenRes = await _customerService.Authenticate(req);

            return Ok(authenRes);
        }

        /// <summary>
        /// Api thêm mới khách hàng
        /// </summary>
        /// CreatedBy: dbhuan 14/02/2022
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCustomerReq req)
        {
            Log.Logger.Debug("CustomerController-CreateAsync\nReq: {req}", JsonConvert.SerializeObject(req));
            _validationService.Validate(req);
            await _customerService.CreateAsync(req);
            return Ok();
        }

        #endregion Hàm
    }
}