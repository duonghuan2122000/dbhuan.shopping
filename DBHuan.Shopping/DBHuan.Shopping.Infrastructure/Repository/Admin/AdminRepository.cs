using DBHuan.Shopping.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHuan.Shopping.Infrastructure.Repository
{
    /// <summary>
    /// Repository admin
    /// </summary>
    /// CreatedBy: dbhuan 27/02/2022
    public class AdminRepository: IAdminRepository
    {
        #region Khởi tạo
        public AdminRepository()
        {

        }
        #endregion

        #region Hàm
        /// <summary>
        /// Lấy thông tin admin bằng id
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        public async Task<Admin> GetAsync(Guid id)
        {
            return null;
        }

        /// <summary>
        /// Tạo mới admin (tạo cả account)
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        public async Task CreateAsync(Admin admin)
        {

        }
        #endregion
    }
}
