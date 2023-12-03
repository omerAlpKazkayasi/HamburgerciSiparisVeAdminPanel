using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entitiess.Concrete.DBcontext;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCartItemDal : EfEntityRepository<CartItem, AppDbContext>, ICartItemDal
    {
        public void AddRange(List<CartItem> cartItems)
        {
            using (var context = new AppDbContext())
            {
                context.CartItems.AddRange(cartItems);
                context.SaveChanges();
            }
        }

        public List<CartItem> GetByCartIdWithProducts(int id)
        {
            using (var context = new AppDbContext())
            {
                var carts = context.CartItems.Where(x => x.CartId == id)
                    .Include(x => x.Product).Where(x => x.ProductId == x.Product.ProductId).ToList();
                return carts;
            }
        }

        public List<CartItem> GetCartItemsByCartId(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.CartItems.Where(x => x.CartId == id).ToList();
            }

        }

        public CartItem QuantityDecrease(int id)
        {
            using (var context = new AppDbContext())
            {

                var cartItem = context.CartItems.Include(x => x.Product).FirstOrDefault(x => x.CartItemId == id);

                cartItem.Quantity--;
                cartItem.TotalPrice = cartItem.Quantity * cartItem.Product.Price;


                context.SaveChanges();
                return cartItem;
            }
        }

        public CartItem QuantityIncrease(int id)
        {
            using (var context = new AppDbContext())
            {

                var cartItem = context.CartItems.Include(x => x.Product).FirstOrDefault(x => x.CartItemId == id);

                cartItem.Quantity++;
                cartItem.TotalPrice = cartItem.Quantity * cartItem.Product.Price;


                context.SaveChanges();
                return cartItem;
            }
        }
    }

}
