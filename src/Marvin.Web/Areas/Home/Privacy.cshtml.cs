using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marvin.Web.Areas.Home
{
    /// <summary>
    /// Privacy Model
    /// </summary>
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Privacy Model
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <exception cref="ArgumentNullException">Logger Null Exception</exception>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get Command
        /// </summary>
        public void OnGet()
        {
            //TODO: is this needed if it is empty?
        }
    }
}