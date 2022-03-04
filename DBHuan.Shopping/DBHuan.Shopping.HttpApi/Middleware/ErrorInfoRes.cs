namespace DBHuan.Shopping.HttpApi
{
    /// <summary>
    /// Tham số res của error
    /// </summary>
    /// CreatedBy: dbhuan 05/02//2022
    public class ErrorInfoRes
    {
        public string ErrorCode { get; set; }

        public string? ErrorMessage { get; set; }

        public IDictionary<string, string>? ValidationsData { get; set; }
    }
}
