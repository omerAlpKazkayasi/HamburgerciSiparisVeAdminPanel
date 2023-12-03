using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductIngredient : IEntity
    {
        //public int ProductIngredientId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }
    }


}
