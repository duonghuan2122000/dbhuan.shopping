using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DBHuan.Shopping.Domain
{
    /// <summary>
    /// Exception dùng chung cho toàn ứng dụng
    /// </summary>
    /// CreatedBy: dbhuan 04/02/2022
    public class DBHuanShoppingException: Exception
    {
        public DBHuanShoppingException(string errorCode, string errorMessage, int statusCode = (int)HttpStatusCode.BadRequest, IDictionary<string, string>? validationsData = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;    
            StatusCode = statusCode;
            ValidationsData = validationsData;
        }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Mô tả mã lỗi
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Thông tin trường invalid
        /// </summary>
        public IDictionary<string, string>? ValidationsData { get; set; }

        /// <summary>
        /// Mã http lỗi
        /// </summary>
        public int StatusCode { get; set; }
    }
}
