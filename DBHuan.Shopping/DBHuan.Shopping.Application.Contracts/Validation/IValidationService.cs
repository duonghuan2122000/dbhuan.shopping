namespace DBHuan.Shopping.Application.Contracts
{
    /// <summary>
    /// Interface validation service
    /// </summary>
    /// CreatedBy: dbhuan 05/02/2022
    public interface IValidationService
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// CreatedBy: dbhuan 05/02/2022
        void Validate<TDto>(TDto dto);
    }
}