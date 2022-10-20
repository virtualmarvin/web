namespace Marvin.Web.Code.Bootstrap
{
    /// <summary>
    /// Options for Hashid
    /// </summary>
    public class HashidOptions
    {
        /// <summary>
        /// Length for the Hashid
        /// </summary>
        public int Length { get; set; } = 11;

        /// <summary>
        /// Salt for the Hashid
        /// </summary>
        public string Salt { get; set; } = string.Empty;
    }
}
