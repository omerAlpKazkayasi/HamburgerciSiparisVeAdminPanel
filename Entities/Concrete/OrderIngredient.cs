using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class OrderIngredient : IEntity
    {
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public int OrderDetailId { get; set; }
    }


}
