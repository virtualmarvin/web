using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Home.V1
{
    /// <summary>
    /// Represents a RESTful service of orders.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("0.9", Deprecated = true)]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Gets a single order.
        /// </summary>
        /// <param name="id">The requested order identifier.</param>
        /// <returns>The requested order.</returns>
        /// <response code="200">The order was successfully retrieved.</response>
        /// <response code="404">The order does not exist.</response>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Order), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id) => Ok(new Order() { Id = id, Customer = "John Doe" });
    }
}
