namespace DBHuan.Shopping.Domain.Shared
{
    /// <summary>
    /// Thông tin lỗi
    /// </summary>
    /// CreatedBy: dbhuan 05/02/2022
    public class AuthErrorInfo
    {
        public class Code
        {
            public const string InvalidAuth = "E1000";

            public const string UsernameOrEmailExist = "E1001";
        }

        public class Message
        {
            public const string InvalidAuth = "Thông tin xác thực không hợp lệ";

            public const string UsernameOrEmailExist = "Username hoặc email đã tồn tại";
        }
    }
}