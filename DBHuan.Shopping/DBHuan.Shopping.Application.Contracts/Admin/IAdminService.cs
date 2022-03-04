namespace DBHuan.Shopping.Application.Contracts
{
    /// <summary>
    /// Interface service của admin
    /// </summary>
    /// CreatedBy: dbhuan 27/02/2022
    public interface IAdminService
    {
        /// <summary>
        /// Lấy thông tin admin bằng id
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        Task<AdminDto> GetAsync(Guid id);

        /// <summary>
        /// Tạo mới admin (tạo cả account)
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        Task CreateAsync(CreateAdminReq admin);
    }
}