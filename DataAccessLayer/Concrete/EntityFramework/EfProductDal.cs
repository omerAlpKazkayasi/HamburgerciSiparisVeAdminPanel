using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entitiess.Concrete.DBcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepository<Product, AppDbContext>, IProductDal
    {
        public decimal GetPriceByProductId(int id)
        {
            return Get(x => x.ProductId == id).Price;
        }

        public List<ProductDetailsDTO> GetProductDetails(int id)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                var productDetailsList = dbContext.Products
                .Include(p => p.ProductIngredients)
                .ThenInclude(pi => pi.Ingredient)
                 .Where(p => p.CategoryId == id)
                .Select(p => new ProductDetailsDTO
                {
                    ProductID = p.ProductId,
                    ProductName = p.ProductName,
                    ProductPrice = p.Price,
                    Ingredients = p.ProductIngredients.Select(pi => new IngredientDTO
                    {
                        IngredientId = pi.Ingredient.IngredientId,
                        IngredientName = pi.Ingredient.IngredientName
                    }).ToList()
                })
                     .ToList();

                return productDetailsList;
            }

        }
        public ProductDetailsDTO GetProductWithDetails(int id)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                var productWithIngredients = dbContext.Products
            .Where(p => p.ProductId == id)
            .Include(p => p.ProductIngredients)
            .ThenInclude(pi => pi.Ingredient)
            .Select(p => new ProductDetailsDTO
            {
                ProductID = p.ProductId,
                ProductName = p.ProductName,
                Ingredients = p.ProductIngredients.Select(pi => new IngredientDTO
                {
                    IngredientId = pi.Ingredient.IngredientId,
                    IngredientName = pi.Ingredient.IngredientName
                }).ToList()
            })
           .FirstOrDefault();

                return productWithIngredients;
            }
        }
        public Product GetProductIngredientsByProductId(int productId)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                return dbContext.Products
          .Include(p => p.ProductIngredients)
          .ThenInclude(pi => pi.Ingredient)
          .FirstOrDefault(p => p.ProductId == productId);
            }
        }
        public void RemoveAllIngredientsFromProduct(int ProductId)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                var Product = dbContext.Products
                .Include(a => a.ProductIngredients)
                .FirstOrDefault(a => a.ProductId == ProductId);

                if (Product != null)
                {
                    foreach (var authorBook in Product.ProductIngredients.ToList())
                    {
                        Product.ProductIngredients.Remove(authorBook);
                    }

                    dbContext.SaveChanges();
                }
            }
        }
        public List<ProductDetailsDTO> GetProductsDetailsForCart(List<int> ids)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                var productDetailsList = dbContext.Products
                    .Include(p => p.ProductIngredients)
                    .ThenInclude(pi => pi.Ingredient)
                    .Where(p => ids.Contains(p.ProductId))
                    .Select(p => new ProductDetailsDTO
                    {
                        ProductID = p.ProductId,
                        ProductName = p.ProductName,
                        ProductPrice = p.Price,
                        Ingredients = p.ProductIngredients.Select(pi => new IngredientDTO
                        {
                            IngredientId = pi.Ingredient.IngredientId,
                            IngredientName = pi.Ingredient.IngredientName
                        }).ToList()
                    })
                    .ToList();

                return productDetailsList;
            }
        }

        public List<Product> GetProductsWithCategory()
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                return dbContext.Products
                    .Include(p => p.Category)
                    .ToList();

            }
        }
    }

}
