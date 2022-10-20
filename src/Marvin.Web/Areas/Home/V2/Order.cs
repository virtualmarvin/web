namespace Marvin.Web.Areas.Home.V2
{
    /// <summary>
    /// A model that represents an Order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The Unique Identifier for an Order
        /// </summary>
        public string HashId { get; set; } = string.Empty;

        /// <summary>
        /// The Unique Identifier for an Order
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Last date of the order
        /// </summary>
        public DateTime LastOrder => DateTime.UtcNow.Date;

        /// <summary>
        /// The name of the Customer
        /// </summary>
        public string Customer { get; set; } = string.Empty;
    }
}
