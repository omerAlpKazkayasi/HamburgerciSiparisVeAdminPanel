using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        // Order ile ilişkili OrderDetails
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }


}
