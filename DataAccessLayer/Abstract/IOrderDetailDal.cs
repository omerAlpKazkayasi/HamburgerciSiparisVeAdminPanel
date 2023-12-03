using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccessLayer.Abstract
{
    public interface IOrderDetailDal : IEntityRepository<OrderDetail>
    {
        public List<UserOrderDetailsDTO> GetUserOrderDetailsByUserId(string userId);
        decimal GetTotalPriceByCartId(int cartId);
    }

}

