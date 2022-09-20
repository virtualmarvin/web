namespace Marvin.Web.Areas.Errors
{
    public class Detail : BaseModel
    {
        #region Data

        public int? Id { get; set; }

        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? CreatedDate { get; set; }
        public string? Message { get; set; }
        public string? Exception { get; set; }
        public string? IpAddress { get; set; }
        public string? Url { get; set; }
        public string? HttpReferer { get; set; }
        public string? UserAgent { get; set; }
        public string? ServerName { get; set; }

        #endregion
    }
}