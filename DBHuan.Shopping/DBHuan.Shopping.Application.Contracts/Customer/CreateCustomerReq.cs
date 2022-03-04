namespace DBHuan.Shopping.Application.Contracts
{
    /// <summary>
    /// Req của api tạo khách hàng
    /// </summary>
    /// CreatedBy: dbhuan 05/02/2022
    public class CreateCustomerReq
    {
        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        [DbhRequired]
        public string Username { get; set; }

        /// <summary>
        /// Mật khẩu đã được mã hóa
        /// </summary>
        [DbhRequired]
        public string Password { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DbhRequired]
        public string Email { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        [DbhRequired]
        public string FirstName { get; set; }

        /// <summary>
        /// Họ và tên đệm
        /// </summary>
        [DbhRequired]
        public string LastName { get; set; }
    }
}


