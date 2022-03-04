using DBHuan.Shopping.Domain;
using System.Text;

namespace DBHuan.Shopping.Infrastructure.Helper
{
    /// <summary>
    /// Common Helper
    /// </summary>
    /// Createdby: dbhuan 13/02/2022
    public class CommonHelper : ICommonHelper
    {
        #region Khởi tạo

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public CommonHelper()
        {
        }

        #endregion Khởi tạo

        #region Hàm

        /// <summary>
        /// Tạo ra một chuỗi với độ dài length
        /// </summary>
        /// CreatedBy: dbhuan 13/02/2022
        public string GenerateString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Mã hóa md5
        /// </summary>
        /// CreatedBy: dbhuan 13/02/2022
        public string ComputedMd5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }

            #endregion Hàm
        }
    }
}