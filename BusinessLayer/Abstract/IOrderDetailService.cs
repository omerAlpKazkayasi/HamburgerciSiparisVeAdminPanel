using Entities.Concrete;
using Entities.DTOs;

namespace BusinessLayer.Abstract
{
    public interface IOrderDetailService
	{
         void Add(OrderDetail orderDetail);
        public List<UserOrderDetailsDTO> GetUserOrderDetailsByUserId(string userId);

        decimal GetTotalPriceByCartId(int cartId);
    }

}
