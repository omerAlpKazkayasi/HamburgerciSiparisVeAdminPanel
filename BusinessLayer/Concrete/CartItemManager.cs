using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace BusinessLayer.Concrete
{
    public class CartItemManager : ICartItemService
    {
        ICartItemDal _cartItemDal;

        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        public void Add(CartItem cartItem)
        {
            _cartItemDal.Add(cartItem);
        }

        public void AddRange(List<CartItem> cartItems)
        {
            _cartItemDal.AddRange(cartItems);
        }

        public void Delete(CartItem cartItem)
        {
            _cartItemDal.Delete(cartItem);
        }

        public CartItem Get()
        {
            return _cartItemDal.Get();
        }

        public List<CartItem> GetAll()
        {
            return _cartItemDal.GetAll();
        }

        public List<CartItem> GetByCartId(int id)
        {
           return _cartItemDal.GetAll(x => x.CartId == id);
        }

        public List<CartItem> GetByCartIdWithProducts(int id)
        {
            return _cartItemDal.GetByCartIdWithProducts(id);
        }

        public CartItem GetById(int id)
        {
            return _cartItemDal.GetById(id);
        }

        public List<CartItem> GetCartItemsByCartId(int id)
        {
            return _cartItemDal.GetCartItemsByCartId(id);
        }

        public CartItem QuantityDecrease(int id)
        {
            if(_cartItemDal.GetById(id).Quantity<2)
            {
                _cartItemDal.Delete(_cartItemDal.GetById(id));
                return null;
            }
            else
            {
                return _cartItemDal.QuantityDecrease(id);
            }
        }

        public CartItem QuantityIncrease(int id)
        {
            if (_cartItemDal.GetById(id).Quantity >= 0)
            {
                return _cartItemDal.QuantityIncrease(id);
            }
            
            throw new System.Exception("Quantity can not be less than 0");  //TODO: Exception handling
        }

        public void Update(CartItem cartItem)
        {
            _cartItemDal.Update(cartItem);
        }
    }
}
