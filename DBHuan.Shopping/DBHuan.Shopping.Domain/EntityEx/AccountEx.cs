using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHuan.Shopping.Domain
{
    /// <summary>
    /// Entity Account
    /// </summary>
    /// CreatedBy: dbhuan 04/02/2022
    public partial class Account
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreatedBy: dbhuan 04/02/2022
        public Account()
        {
            Id = Guid.NewGuid();
            PasswordSalt = Guid.NewGuid().ToString();
        }
    }
}
