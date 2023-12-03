using Entities.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICartService
    {
        List<CartItem> GetAll();
        CartItem Get();
        CartItem GetById(int id);
        void Add(CartItem cartItem);
        void Update(CartItem cartItem);
        void Delete(CartItem cartItem);
        Cart GetCartByUserId(string id);

        



    }

}
