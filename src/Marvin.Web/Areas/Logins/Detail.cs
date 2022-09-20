namespace Marvin.Web.Areas.Logins
{
    public class Detail : BaseModel
    {
        #region Data

        public int Id { get; set; }
        public string? LoginDate { get; set; }
        
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? IpAddress { get; set; }
        public string? Result { get; set; }

        #endregion
    }
}
