namespace DBHuan.Shopping.Domain
{
    /// <summary>
    /// Account Admin
    /// </summary>
    public partial class Admin
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreatedBy: dbhuan 04/02/2022
        public Admin()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public Admin Update()
        {
            UpdatedDate = DateTime.Now;
            return this;
        }
    }
}