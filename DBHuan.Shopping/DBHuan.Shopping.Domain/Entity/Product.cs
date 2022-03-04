namespace DBHuan.Shopping.Domain
{
    /// <summary>
    /// Sản phẩm
    /// </summary>
    /// CreatedBy: dbhuan 16/02/2022
    public class Product
    {
        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Slug sản phẩm
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Ảnh đại diện sản phẩm
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// Mô tả sản phẩm
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Thông số bổ sung
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// Danh mục sản phẩm
        /// </summary>
        public Category Category { get; set; }

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