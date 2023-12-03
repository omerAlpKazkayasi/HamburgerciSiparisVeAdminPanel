using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        public decimal GetPriceByProductId(int id);

        public List<ProductDetailsDTO> GetProductDetails(int id);
        public ProductDetailsDTO GetProductWithDetails(int id);
        public Product GetProductIngredientsByProductId(int productId);
        public void RemoveAllIngredientsFromProduct(int ProductId);

        public List<ProductDetailsDTO> GetProductsDetailsForCart(List<int> ids);

        List<Product> GetProductsWithCategory();
    }

}

