using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public Product()
        {
            ProductIngredients = new HashSet<ProductIngredient>();
            OrderDetails = new HashSet<OrderDetail>();
            CartItems = new HashSet<CartItem>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? SizeId { get; set; }
        public Size? Size { get; set; }

        public ICollection<ProductIngredient> ProductIngredients { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }


}
