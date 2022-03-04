using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHuan.Shopping.Application.Contracts
{
    /// <summary>
    /// Interface service của khách hàng
    /// </summary>
    /// CreatedBY: dbhuan 05/02/2022
    public interface ICustomerService
    {
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// CreatedBY: dbhuan 05/02/2022
        Task CreateAsync(CreateCustomerReq req);

        /// <summary>
        /// Xác minh khách hàng
        /// </summary>
        /// CreatedBy: dbhuan 14/02/2022
        /// <param name="req"></param>
        /// <returns></returns>
        Task<AuthenticateCustomerRes> Authenticate(AuthenticateCustomerReq req);

        /// <summary>
        /// Lấy thông tin khách hàng
        /// </summary>
        /// CreatedBy: dbhuan 14/02/2022
        Task<CustomerDto> GetAsync(Guid id);
    }
}
