using DBHuan.Shopping.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBHuan.Shopping.Test
{
    /// <summary>
    /// Test cho db
    /// </summary>
    /// CreatedBY: dbhuan 27/02/2022
    [TestClass]
    public class DBHuanShoppingDbContextTest
    {
        private IConfiguration _configuration;

        /// <summary>
        /// Khởi tạo các đối tượng
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        [TestInitialize]
        public void Inititalize()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
        }

        /// <summary>
        /// Test kết nối tới db
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        [TestMethod]
        public void DBHuanShoppingDbContextTest_Connect()
        {
            var dbContext = new DBHuanShoppingDbContext(_configuration);

            Assert.IsNotNull(dbContext.Connection);
        }
    }
}