using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Size : IEntity
    {
        public Size()
        {
            Products = new HashSet<Product>();
        }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public ICollection<Product> Products{ get; set; }
    }


}
