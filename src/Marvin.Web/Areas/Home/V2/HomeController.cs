using HashidsNet;
using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Home.V2
{
    /// <summary>
    /// Represents a RESTful service of orders.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IHashids _hashids;

        /// <summary>
        /// Represents a RESTful service of orders
        /// </summary>
        /// <param name="hashids"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public HomeController(IHashids hashids)
        {
            _hashids = hashids ?? throw new ArgumentNullException(nameof(hashids));
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>A collection of orders</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Order[]), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetAll()
        {
            var collection = new Order[3];
            collection[0] = new Order() { Id = 1, HashId = _hashids.Encode(1), Customer = "John Doe" };
            collection[1] = new Order() { Id = 2, HashId = _hashids.Encode(2), Customer = "Jane Doe" };
            collection[2] = new Order() { Id = 3, HashId = _hashids.Encode(3), Customer = "John Jane" };
            return Ok(collection);
        }

        /// <summary>
        /// Gets a single order.
        /// </summary>
        /// <param name="hashid">The requested order identifier.</param>
        /// <returns>The requested order.</returns>
        /// <response code="200">The order was successfully retrieved.</response>
        /// <response code="404">The order does not exist.</response>
        [HttpGet("{hashid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Order), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(string hashid)
        {
            var id = _hashids.Decode(hashid);

            if(id.Length == 0)
            {
                return NotFound();
            }

            return Ok(new Order() { Id = id[0], HashId = _hashids.Encode(id[0]), Customer = "John Doe" });
        }

    }
}
