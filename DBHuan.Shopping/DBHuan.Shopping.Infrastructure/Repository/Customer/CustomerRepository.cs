using Dapper;
using DBHuan.Shopping.Domain;
using DBHuan.Shopping.Domain.Shared;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Net;

namespace DBHuan.Shopping.Infrastructure.Repository
{
    /// <summary>
    /// Repository của khách hàng
    /// </summary>
    /// Createdby: dbhuan 13/02/2022
    public class CustomerRepository : ICustomerRepository
    {
        #region Khởi tạo

        private readonly IConfiguration _configuration;

        private readonly ICommonHelper _commonHelper;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// CreatedBy: dbhuan 13/02/2022
        public CustomerRepository(IConfiguration configuration, ICommonHelper commonHelper)
        {
            _configuration = configuration;
            _commonHelper = commonHelper;
        }

        #endregion Khởi tạo

        #region Hàm

        /// <summary>
        /// Tạo mới một khách hàng
        /// </summary>
        /// CreatedBy: dbhuan 13/02/2022
        public async Task CreateAsync(Customer customer)
        {
            /// <summary>
            /// usecase: Tạo mới một khách hàng
            /// 1. Thêm mới bản ghi account
            /// 1.1 Kiểm tra username và email unique trước khi thêm
            /// 2. Thêm mới bản ghi khách hàng
            /// </summary>

            using var dbContext = new DBHuanShoppingDbContext(_configuration);
            var connection = dbContext.Connection;
            await connection.OpenAsync();
            using var transaction = connection.BeginTransaction();
            try
            {
                string sqlGetAccount = @"SELECT * FROM account WHERE Username = @Username OR Email = @Email LIMIT 1";
                Account accountExist = await connection.QueryFirstOrDefaultAsync<Account>(sqlGetAccount, new
                {
                    Email = customer.Account.Email,
                    Username = customer.Account.Username,
                });

                if (accountExist != null)
                {
                    throw new DBHuanShoppingException(AuthErrorInfo.Code.UsernameOrEmailExist, AuthErrorInfo.Message.UsernameOrEmailExist);
                }

                string sqlCreateAccount = @"INSERT INTO account (Id, Username, Password, Email, PasswordSalt)
                    VALUES (@Id, @Username, @Password, @Email, @PasswordSalt); ";
                var passwordSalt = _commonHelper.GenerateString(8);
                var passwordHash = _commonHelper.ComputedMd5(customer.Account.Password + passwordSalt);
                await connection.ExecuteAsync(sqlCreateAccount, new
                {
                    Id = customer.Account.Id,
                    Username = customer.Account.Username,
                    Password = passwordHash,
                    Email = customer.Account.Email,
                    PasswordSalt = passwordSalt
                });

                string sqlCreateCustomer = @"INSERT INTO customer (Id, AccountId, FirstName, LastName, CreatedDate)
                    VALUES (@Id, @AccountId, @FirstName, @LastName, @CreatedDate);";

                await connection.ExecuteAsync(sqlCreateCustomer, new
                {
                    Id = customer.Id,
                    AccountId = customer.Account.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    CreatedDate = customer.CreatedDate
                });
                await transaction.CommitAsync();
            }
            catch (DBHuanShoppingException ex)
            {
                Log.Logger.Error("CustomerRepository-CreateAsync\nEx: {ex}", ex);
                throw;
            }
            catch (Exception ex)
            {
                Log.Logger.Error("CustomerRepository-CreateAsync\nEx: {ex}", ex);
                await transaction.RollbackAsync();
                throw new DBHuanShoppingException(ErrorInfo.Code.InternalServerError, ErrorInfo.Message.InternalServerError, (int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Lấy thông tin khách hàng dựa vào username và password
        /// </summary>
        /// CreatedBy: dbhuan 14/02/2022
        public async Task<Customer> GetAsync(string username, string password)
        {
            using var dbContext = new DBHuanShoppingDbContext(_configuration);
            var connection = dbContext.Connection;
            await connection.OpenAsync();

            string sqlGetAccount = "SELECT * FROM account WHERE Username = @Username OR Email = @Email LIMIT 1";
            var account = await connection.QueryFirstOrDefaultAsync<Account>(sqlGetAccount, new
            {
                Username = username,
                Email = username
            });

            if (account == null)
                throw new DBHuanShoppingException(AuthErrorInfo.Code.InvalidAuth, AuthErrorInfo.Message.InvalidAuth);

            var passwordHash = _commonHelper.ComputedMd5(password + account.PasswordSalt);
            if (!passwordHash.Equals(account.Password))
                throw new DBHuanShoppingException(AuthErrorInfo.Code.InvalidAuth, AuthErrorInfo.Message.InvalidAuth);

            string sqlGetCustomer = "SELECT * FROM customer WHERE AccountId = @AccountId LIMIT 1";
            var customer = await connection.QueryFirstOrDefaultAsync<Customer>(sqlGetCustomer, new
            {
                AccountId = account.Id
            });

            if (customer == null)
                throw new DBHuanShoppingException(AuthErrorInfo.Code.InvalidAuth, AuthErrorInfo.Message.InvalidAuth);

            customer.Account = account;
            return customer;
        }

        /// <summary>
        /// Lấy thông tin khách hàng
        /// </summary>
        /// CreatedBy: dbhuan 14/02/2022
        public async Task<Customer> GetAsync(Guid id)
        {
            using var dbContext = new DBHuanShoppingDbContext(_configuration);
            var connection = dbContext.Connection;
            await connection.OpenAsync();

            string sqlGetCustomer = "SELECT * FROM customer WHERE Id = @Id LIMIT 1";
            var customer = await connection.QueryFirstOrDefaultAsync<Customer>(sqlGetCustomer, new
            {
                Id = id
            });

            return customer;
        }

        #endregion Hàm
    }
}