using AutoMapper;
using DBHuan.Shopping.Application.Contracts;
using DBHuan.Shopping.Domain;
using DBHuan.Shopping.Domain.Shared;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DBHuan.Shopping.Application
{
    /// <summary>
    /// Service của khách hàng
    /// </summary>
    /// CreatedBy: dbhuan 05/02/2022
    public class CustomerService : ICustomerService
    {
        #region Khởi tạo

        private readonly ICustomerRepository _customerRepository;

        private readonly JwtOption _jwtOption;

        private readonly IMapper _mapper;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreatedBy: dbhuan 13/02/2022
        public CustomerService(ICustomerRepository customerRepository, IOptions<JwtOption> jwtOption, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _jwtOption = jwtOption.Value;
            _mapper = mapper;
        }

        #endregion Khởi tạo

        #region Hàm

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// CreatedBY: dbhuan 05/02/2022
        public async Task CreateAsync(CreateCustomerReq req)
        {
            var customer = new Customer
            {
                Account = new Account
                {
                    Username = req.Username,
                    Password = req.Password,
                    Email = req.Email,
                },
                FirstName = req.FirstName,
                LastName = req.LastName,
            };
            await _customerRepository.CreateAsync(customer);
        }

        /// <summary>
        /// Xác minh khách hàng
        /// </summary>
        /// CreatedBy: dbhuan 14/02/2022
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<AuthenticateCustomerRes> Authenticate(AuthenticateCustomerReq req)
        {
            var customer = await _customerRepository.GetAsync(req.Username, req.Password);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.Key));
            var credentitals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(AuthClaimTypes.Id, customer.Id.ToString()),
                new Claim(AuthClaimTypes.FirstName, customer.FirstName),
                new Claim(AuthClaimTypes.LastName, customer.LastName)
            };

            var token = new JwtSecurityToken(
                _jwtOption.Issuer,
                _jwtOption.Issuer,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentitals
            );

            return new AuthenticateCustomerRes
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        /// <summary>
        /// Lấy thông tin khách hàng
        /// </summary>
        /// CreatedBy: dbhuan 14/02/2022
        public async Task<CustomerDto> GetAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsync(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        #endregion Hàm
    }
}