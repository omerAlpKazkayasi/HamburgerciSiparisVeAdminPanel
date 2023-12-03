using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace BusinessLayer.Concrete
{
    public class  OrderManager:IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Order order)
        {
            _orderDal.Add(order);
        }


    }
}
