using DBHuan.Shopping.Domain.Shared;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DBHuan.Shopping.Infrastructure
{
    /// <summary>
    /// DbContext của ứng dụng
    /// </summary>
    /// CreatedBy: dbhuan 05/02/2022
    public class DBHuanShoppingDbContext : IDisposable
    {
        private readonly string ConnectionString;

        public readonly MySqlConnection Connection;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreatedBy: dbhuan 05/02/2022
        public DBHuanShoppingDbContext(IConfiguration _configuration)
        {
            ConnectionString = _configuration.GetConnectionString(DbConst.DbConnectionString);
            Connection = new MySqlConnection(ConnectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}