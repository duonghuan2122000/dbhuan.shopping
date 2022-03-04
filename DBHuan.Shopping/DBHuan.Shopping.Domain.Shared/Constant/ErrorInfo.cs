using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHuan.Shopping.Domain.Shared
{
    /// <summary>
    /// Thông tin lỗi
    /// </summary>
    /// CreatedBy: dbhuan 04/02/2022
    public class ErrorInfo
    {
        public class Code
        {
            public const string UnAuthorized = "E2000";

            public const string InputInValid = "E2001";

            public const string InternalServerError = "E3000";
        }

        public class Message
        {
            public const string UnAuthorized = "Yêu cầu xác thực";

            public const string InputInValid = "Tham số req không hợp lệ";

            public const string InternalServerError = "Có lỗi xảy ra";
        }
    }
}
