using Dapper;
using DBHuan.Shopping.Domain;
using DBHuan.Shopping.Domain.Shared;
using DBHuan.Shopping.Infrastructure;
using DBHuan.Shopping.Infrastructure.Helper;
using DBHuan.Shopping.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MySql.Data.MySqlClient;

namespace DBHuan.Shopping.Test
{
    /// <summary>
    /// Test repository khách hàng
    /// </summary>
    /// CreatedBy: dbhuan 27/02/2022
    [TestClass]
    public class CustomerRepositoryTest
    {
        private IConfiguration configuration;
        private Mock<MySqlConnection> mockConnection;
        private Mock<DBHuanShoppingDbContext> mockDbContext;
        private ICustomerRepository customerRepository;
        private ICommonHelper helper;

        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// CreatedBy: dbhuan 27/02/2022
        [TestInitialize]
        public void Inititalize()
        {
            configuration = new ConfigurationBuilder()
               .AddJsonFile(Directory.GetCurrentDirectory() + "/appsettings.test.json")
               .AddEnvironmentVariables()
               .Build();
            mockDbContext = new Mock<DBHuanShoppingDbContext>();
            mockConnection = new Mock<MySqlConnection>(MockBehavior.Strict, new object[] { configuration.GetConnectionString(DbConst.DbConnectionString) });
            helper = new CommonHelper();
            customerRepository = new CustomerRepository(configuration, helper);
        }

        //[TestMethod]
        //public async Task CustomerRepositoryTest_GetAsync()
        //{
        //    var id = Guid.NewGuid();
        //    string sqlGetCustomer = "SELECT * FROM customer WHERE Id = @Id LIMIT 1";
        //    Customer customer = new Customer
        //    {
        //        Id = id,
        //    };

        //    mockDbContext.Setup(dbContext => dbContext.Connection).Returns(mockConnection.Object);
        //    mockConnection.Setup(connection => connection.QueryFirstOrDefaultAsync(sqlGetCustomer, new {Id = id}, null, null, null)).ReturnsAsync(customer);

        //    var cTest = await customerRepository.GetAsync(id);
        //    Assert.IsNotNull(cTest);
        //    Assert.AreEqual(customer, cTest);
        //}
    }
}