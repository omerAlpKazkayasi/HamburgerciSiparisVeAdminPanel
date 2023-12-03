using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace BusinessLayer.Concrete
{
    public class ProductManager:IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
           return _productDal.GetAll();
        }

        public List<Product> GetAllByCategory(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<ProductDetailsDTO> GetDetail(int id)
        {
            return _productDal .GetProductDetails(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetAll(x=>x.SizeId == 1 || x.SizeId== null);
        }

        public decimal GetPriceByProductId(int id)
        {
            return _productDal.GetPriceByProductId(id);
        }

        public Product GetProductIngredientsByProductId(int productId)
        {
            return _productDal.GetProductIngredientsByProductId(productId);
        }

        public List<ProductDetailsDTO> GetProductsDetailsForCart(List<int> ids)
        {
            return _productDal.GetProductsDetailsForCart(ids);
        }

        public List<Product> GetProductsWithCategory()
        {
            return _productDal.GetProductsWithCategory();
        }

        public ProductDetailsDTO GetProductWithDetails(int id)
        {
            return _productDal.GetProductWithDetails(id);
        }

        public void RemoveAllIngredientsFromProduct(int ProductId)
        {
            _productDal.RemoveAllIngredientsFromProduct(ProductId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
