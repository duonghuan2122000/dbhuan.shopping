using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHuan.Shopping.Domain
{
    /// <summary>
    /// Interface common helper
    /// </summary>
    /// CreatedBy: dbhuan 13/02/2022
    public interface ICommonHelper
    {
        /// <summary>
        /// Tạo ra một chuỗi với độ dài length
        /// </summary>
        /// CreatedBy: dbhuan 13/02/2022
        string GenerateString(int length);

        /// <summary>
        /// Mã hóa md5
        /// </summary>
        /// CreatedBy: dbhuan 13/02/2022
        string ComputedMd5(string input);
    }
}
