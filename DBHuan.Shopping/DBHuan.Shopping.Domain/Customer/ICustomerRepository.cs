namespace DBHuan.Shopping.Domain
{
    /// <summary>
    /// Interface repository của khách hàng
    /// </summary>
    /// CreatedBy: dbhuan 13/02/2022
    public interface ICustomerRepository
    {
        /// <summary>
        /// Tạo mới một khách hàng
        /// </summary>
        /// CreatedBy: dbhuan 13/02/2022
        Task CreateAsync(Customer customer);

        /// <summary>
        /// Lấy thông tin khách hàng dựa vào username và password
        /// </summary>
        /// CreatedBy: dbhuan 14/02/2022
        Task<Customer> GetAsync(string username, string password);

        /// <summary>
        /// Lấy thông tin khách hàng
        /// </summary>
        /// CreatedBy: dbhuan 14/02/2022
        Task<Customer> GetAsync(Guid id);
    }
}