using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entitiess.Concrete.DBcontext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepository<Cart, AppDbContext>, ICartDal
    {
        public Cart GetCartByUserId(string id)
        {
                return Get(x => x.UserId == id);
        }

        

        //public List<Cart> GetCartByUserId(int id)
        //{
        //    using (AppDbContext c = new AppDbContext())
        //    {
        //        var result = c.Cart.Include(x => x.CartItems).Where(x => x.UserId == id).ToList();
        //        return result;
        //    }
        //}
    }

}
