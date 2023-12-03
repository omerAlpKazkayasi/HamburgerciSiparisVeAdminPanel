using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entitiess.Concrete.DBcontext;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfOrderDetailDal : EfEntityRepository<OrderDetail, AppDbContext>, IOrderDetailDal
    {
        public List<UserOrderDetailsDTO> GetUserOrderDetailsByUserId(string userId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                          
                var productDetailsList = context.Orders
                    .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                    .Where(o => o.UserId == userId)
                    .Select(o => new UserOrderDetailsDTO
                    {
                        OrderId = o.OrderId,
                        UserId = o.UserId,
                        TotalPrice = o.TotalPrice,
                        CreateDate = o.OrderDate,
                        OrderDetailsWithProductNames = o.OrderDetails.Select(od => new OrderDetailsWithProductNamesDTO
                        {
                            OrderDetailId = od.OrderDetailId,
                            ProductId = od.ProductId,
                            ProductName = od.Product.ProductName,
                            Quantity = od.Quantity,
                            RemoverIngredient = od.RemovedIngredients
                        }).ToList()
                    }).ToList();
                

                return productDetailsList;
            }
        }

        public decimal GetTotalPriceByCartId(int cartId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var totalPrice = context.CartItems.Where(od => od.CartId == cartId).Sum(od => od.TotalPrice);

                return totalPrice;
            }
        }

    }


}
