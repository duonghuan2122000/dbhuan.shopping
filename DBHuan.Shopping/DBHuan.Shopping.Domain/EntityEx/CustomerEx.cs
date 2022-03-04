namespace DBHuan.Shopping.Domain
{
    /// <summary>
    /// Account Customer
    /// </summary>
    /// CreatedBy: dbhuan 04/02/2022
    public partial class Customer
    {
        public Customer()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public Customer Update()
        {
            UpdatedDate = DateTime.Now;
            return this;
        }
    }
}