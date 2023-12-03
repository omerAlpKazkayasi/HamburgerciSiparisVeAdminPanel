using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Ingredient : IEntity
    {
        public Ingredient()
        {
            ProductIngredients = new HashSet<ProductIngredient>();
            OrderIngredients = new HashSet<OrderIngredient>();
        }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public ICollection<ProductIngredient> ProductIngredients { get; set; }
        public ICollection<OrderIngredient> OrderIngredients { get; set; }
    }


}
