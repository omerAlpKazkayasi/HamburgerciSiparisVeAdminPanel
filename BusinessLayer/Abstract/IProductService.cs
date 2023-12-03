using Entities.Concrete;
using Entities.DTOs;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllByCategory(int id);
        List<Product> GetList();

        decimal GetPriceByProductId(int id);

        List<ProductDetailsDTO> GetDetail(int id);
        ProductDetailsDTO GetProductWithDetails(int id);
        public Product GetProductIngredientsByProductId(int productId);
        void RemoveAllIngredientsFromProduct(int ProductId);

        public List<ProductDetailsDTO> GetProductsDetailsForCart(List<int> ids);


        List<Product> GetProductsWithCategory();
    }

}
