using AutoMapper;
using DBHuan.Shopping.Application.Contracts;
using DBHuan.Shopping.Domain;

namespace DBHuan.Shopping.Application
{
    /// <summary>
    /// Service của admin
    /// </summary>
    /// CreatedBy: dbhuan 27/02/2022
    public class AdminService : IAdminService
    {
        #region Khởi tạo

        /// <summary>
        /// Repo của admin
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        private readonly IAdminRepository _adminRepository;

        /// <summary>
        /// auto mapper
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        #endregion Khởi tạo

        #region Hàm

        /// <summary>
        /// Lấy thông tin admin bằng id
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        public async Task<AdminDto> GetAsync(Guid id)
        {
            var admin = await _adminRepository.GetAsync(id);
            return _mapper.Map<AdminDto>(admin);
        }

        /// <summary>
        /// Tạo mới admin (tạo cả account)
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        public async Task CreateAsync(CreateAdminReq createAdminReq)
        {
            Admin admin = new Admin
            {
                Account = new Account
                {
                    Username = createAdminReq.Username,
                    Password = createAdminReq.Password, // Plain password
                    Email = createAdminReq.Email,
                },
                FirstName = createAdminReq.FirstName,
                LastName = createAdminReq.LastName,
            };
            await _adminRepository.CreateAsync(admin);
        }

        #endregion Hàm
    }
}