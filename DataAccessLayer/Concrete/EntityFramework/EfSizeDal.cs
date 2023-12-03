using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entitiess.Concrete.DBcontext;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfSizeDal : EfEntityRepository<Size, AppDbContext>, ISizeDal
    {

    }

}
