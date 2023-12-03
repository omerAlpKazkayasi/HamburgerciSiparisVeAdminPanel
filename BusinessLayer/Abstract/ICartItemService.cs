using Entities.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICartItemService
	{
        List<CartItem> GetAll();
        CartItem Get();
        CartItem GetById(int id);
        void Add(CartItem cartItem);
        void Update(CartItem cartItem);
        void Delete(CartItem cartItem);

        void AddRange(List<CartItem> cartItems);
        
        CartItem QuantityIncrease(int id);

        CartItem QuantityDecrease(int id);

        List<CartItem> GetByCartId(int id);

        List<CartItem> GetByCartIdWithProducts (int id);

        List<CartItem> GetCartItemsByCartId(int id);
    }

}
