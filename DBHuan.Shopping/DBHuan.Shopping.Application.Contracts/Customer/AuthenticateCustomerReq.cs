namespace DBHuan.Shopping.Application.Contracts
{
    /// <summary>
    /// Tham số của api authen khách hàng
    /// </summary>
    /// CreatedBy: dbhuan 05/028/2022
    public class AuthenticateCustomerReq
    {
        [DbhRequired]
        public string Username { get; set; }

        [DbhRequired]
        public string Password { get; set; }
    }
}