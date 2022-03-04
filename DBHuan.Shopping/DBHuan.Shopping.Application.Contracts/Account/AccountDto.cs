namespace DBHuan.Shopping.Application.Contracts
{
    /// <summary>
    /// Dto của account
    /// </summary>
    /// CreatedBy: dbhuan 14/02/2022
    public class AccountDto
    {
        /// <summary>
        /// Id khóa chính
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Mật khẩu đã được mã hóa
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Khóa bí mật cho mật khẩu
        /// </summary>
        public string PasswordSalt { get; set; }
    }
}