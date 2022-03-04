namespace DBHuan.Shopping.Domain
{
    /// <summary>
    /// Danh mục sản phẩm
    /// </summary>
    /// CreatedBy: dbhuan 16/02/2022
    public class Category
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tên danh mục
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Slug danh mục
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }
}