using Core.DataAccess;
using Entities.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICartDal : IEntityRepository<Cart>
    {
        public Cart GetCartByUserId(string id);

    }

}

