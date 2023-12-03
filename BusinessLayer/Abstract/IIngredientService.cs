using Entities.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IIngredientService
	{
        List<Ingredient> GetAll();
        Ingredient GetById(int id);
        void Add(Ingredient ingredient);
        void Update(Ingredient ingredient);
        void Delete(Ingredient ingredient);
    }

}
