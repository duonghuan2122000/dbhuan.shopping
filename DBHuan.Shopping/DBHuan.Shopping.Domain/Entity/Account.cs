namespace DBHuan.Shopping.Domain
{
    /// <summary>
    /// Entity Account
    /// </summary>
    /// CreatedBy: dbhuan 04/02/2022
    public partial class Account
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