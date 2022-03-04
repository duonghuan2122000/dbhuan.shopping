namespace DBHuan.Shopping.Application.Contracts
{
    /// <summary>
    /// Dto của khách hàng
    /// </summary>
    /// CreatedBy: dbhuan 14/02/2022
    public class CustomerDto
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tài khoản
        /// </summary>
        public AccountDto Account { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Họ và tên đệm
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Thời gian cập nhật
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}