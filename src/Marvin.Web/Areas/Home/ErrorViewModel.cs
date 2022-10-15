namespace Marvin.Web.Areas.Home
{
    /// <summary>
    /// The standard error view model for public error page
    /// </summary>
    public sealed class ErrorViewModel
    {
        /// <summary>
        /// The Request Id.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Flag whether to show the Request Id.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
