using DBHuan.Shopping.Application.Contracts;
using DBHuan.Shopping.Domain;
using DBHuan.Shopping.Domain.Shared;
using System.Reflection;

namespace DBHuan.Shopping.Application
{
    /// <summary>
    /// Service validation
    /// </summary>
    /// CreatedBy: dbhuan 05/02/2022
    public class ValidationService : IValidationService
    {
        #region Khởi tạo

        public ValidationService()
        {
        }

        #endregion Khởi tạo

        #region Hàm

        /// <summary>
        /// Validate
        /// </summary>
        /// CreatedBy: dbhuan 05/02/2022
        public void Validate<TDto>(TDto dto)
        {
            #region Lấy ra tất cả các thuộc tính của dto

            var properties = typeof(TDto).GetProperties();

            #endregion Lấy ra tất cả các thuộc tính của dto

            #region Thực hiện validate cho từng thuộc tính

            foreach (var property in properties)
            {
                // required
                ValidateRequired(property, dto);
            }

            #endregion Thực hiện validate cho từng thuộc tính
        }

        /// <summary>
        /// Validate required
        /// </summary>
        /// CreatedBy: dbhuan 05/02/2022
        private void ValidateRequired<TDto>(PropertyInfo property, TDto dto)
        {
            // required
            var requiredProperties = property.GetCustomAttributes(typeof(DbhRequired), true);

            if (requiredProperties.Length > 0)
            {
                // lấy giá trị thuộc tính
                var propertyValue = property.GetValue(dto);

                if (propertyValue == null || string.IsNullOrEmpty(propertyValue.ToString()))
                {
                    var requiredProperty = requiredProperties[0] as DbhRequired;
                    var propertyName = property.Name.ToString().ToCamelCase();

                    throw new DBHuanShoppingException(
                        ErrorInfo.Code.InputInValid,
                        ErrorInfo.Message.InputInValid,
                        validationsData: new Dictionary<string, string>
                        {
                            { propertyName, "required" }
                        });
                }
            }
        }

        #endregion Hàm
    }

    public static class StringExtensions
    {
        /// <summary>
        /// Chuyển str sang dạng camelcase
        /// </summary>
        /// CreatedBy: dbhuan 05/02/2022
        public static string ToCamelCase(this string str)
        {
            var words = str.Split(new[] { "_", " " }, StringSplitOptions.RemoveEmptyEntries);
            var leadWord = words[0].ToLower();
            var tailWords = words.Skip(1)
                .Select(word => char.ToUpper(word[0]) + word.Substring(1))
                .ToArray();
            return $"{leadWord}{string.Join(string.Empty, tailWords)}";
        }
    }
}