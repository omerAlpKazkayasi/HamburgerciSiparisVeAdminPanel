using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public OrderDetail()
        {
            OrderIngredients = new HashSet<OrderIngredient>();
        }
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public string? RemovedIngredients { get; set; }
        //public Size Size { get; set; }
        //public int SizeId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ICollection<OrderIngredient> OrderIngredients { get; set; }
    }


}
