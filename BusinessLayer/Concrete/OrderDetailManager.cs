using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace BusinessLayer.Concrete
{
    public class OrderDetailManager:IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
        }

        public decimal GetTotalPriceByCartId(int cartId)
        {
            return _orderDetailDal.GetTotalPriceByCartId(cartId);
        }

        public List<UserOrderDetailsDTO> GetUserOrderDetailsByUserId(string userId)
        {
            return _orderDetailDal.GetUserOrderDetailsByUserId(userId);
        }
    }
}
