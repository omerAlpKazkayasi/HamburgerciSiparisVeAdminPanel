using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Category ile ilişkili ürünler
        public ICollection<Product> Products { get; set; }

    }


}
