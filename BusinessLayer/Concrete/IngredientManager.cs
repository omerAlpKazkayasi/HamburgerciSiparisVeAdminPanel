using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace BusinessLayer.Concrete
{
    public class IngredientManager:IIngredientService
    {
        IIngredientDal _ingredientDal;

        public IngredientManager(IIngredientDal ingredientDal)
        {
            _ingredientDal = ingredientDal;
        }

        public void Add(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public List<Ingredient> GetAll()
        {
           return _ingredientDal.GetAll();
        }

        public Ingredient GetById(int id)
        {
            return _ingredientDal.Get(i => i.IngredientId == id);
        }

        public void Update(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
