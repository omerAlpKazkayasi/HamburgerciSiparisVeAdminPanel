using Entities.Concrete;
using Entitiess.Concrete;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
	{
		List<Category> GetAll();
        Category Get();
        Category GetById(int id);
		void Add(Category category);
		void Update(Category category);
		void Delete(Category category);
		
	}

}
