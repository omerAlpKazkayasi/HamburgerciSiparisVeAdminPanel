using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entitiess.Concrete.DBcontext;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfIngredientDal : EfEntityRepository<Ingredient, AppDbContext>, IIngredientDal
    {

    }

}
