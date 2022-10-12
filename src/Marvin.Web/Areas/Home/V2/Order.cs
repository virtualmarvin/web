namespace Marvin.Web.Areas.Home.V2
{
    /// <summary>
    /// A model that represents an Order
    /// </summary>
    public class Order : V1.Order
    {
        /// <summary>
        /// Last date of the order
        /// </summary>
        public DateTime LastOrder => DateTime.UtcNow.Date;
    }
}
