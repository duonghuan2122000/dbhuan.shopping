using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHuan.Shopping.Domain
{
    /// <summary>
    /// Interface repository của admin
    /// </summary>
    /// CreatedBy: dbhuan 27/02/2022
    public interface IAdminRepository
    {
        /// <summary>
        /// Lấy thông tin admin bằng id
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        Task<Admin> GetAsync(Guid id);

        /// <summary>
        /// Tạo mới admin (tạo cả account)
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        Task CreateAsync(Admin admin);
    }
}
