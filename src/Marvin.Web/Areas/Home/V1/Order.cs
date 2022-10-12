namespace Marvin.Web.Areas.Home.V1
{
    /// <summary>
    /// A model that represents an Order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The Unique Identifier for an Order
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Customer
        /// </summary>
        public string Customer { get; set; } = string.Empty;
    }
}
