using Core.DataAccess;
using DataAccessLayer.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICartItemDal : IEntityRepository<CartItem>
	{
        public void AddRange(List<CartItem> cartItems);
        public CartItem QuantityIncrease(int id);
        public CartItem QuantityDecrease(int id);

        public List<CartItem> GetByCartIdWithProducts(int id);

        List<CartItem> GetCartItemsByCartId(int id);

    }

}

