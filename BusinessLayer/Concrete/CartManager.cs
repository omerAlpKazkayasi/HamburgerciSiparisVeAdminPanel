using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Entities.Concrete;

namespace BusinessLayer.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;


        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void Add(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public CartItem Get()
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public CartItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Cart GetCartByUserId(string id)
        {
            return _cartDal.GetCartByUserId(id);
        }

        public void Update(CartItem cartItem)
        {
            throw new NotImplementedException();
        }
    }
}
