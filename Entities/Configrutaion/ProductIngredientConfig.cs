using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configrutaion
{
    public class ProductIngredientConfig : IEntityTypeConfiguration<ProductIngredient>
    {
        public void Configure(EntityTypeBuilder<ProductIngredient> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.IngredientId });
            builder.HasOne(x => x.Product).WithMany(x => x.ProductIngredients).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Ingredient).WithMany(x => x.ProductIngredients).HasForeignKey(x => x.IngredientId);

            builder.HasData(
                new ProductIngredient { ProductId = 1, IngredientId = 1 },
                new ProductIngredient { ProductId = 1, IngredientId = 2 },
                new ProductIngredient { ProductId = 1, IngredientId = 3 },
                new ProductIngredient { ProductId = 1, IngredientId = 4 },
                new ProductIngredient { ProductId = 1, IngredientId = 5 },
                new ProductIngredient { ProductId = 1, IngredientId = 6 },
                new ProductIngredient { ProductId = 2, IngredientId = 1 },
                new ProductIngredient { ProductId = 2, IngredientId = 2 },
                new ProductIngredient { ProductId = 2, IngredientId = 3 },
                new ProductIngredient { ProductId = 2, IngredientId = 4 },
                new ProductIngredient { ProductId = 2, IngredientId = 5 },
                new ProductIngredient { ProductId = 2, IngredientId = 6 },
                //new ProductIngredient { ProductId = 3, IngredientId = 8 },
                new ProductIngredient { ProductId = 3, IngredientId = 1 },
                new ProductIngredient { ProductId = 3, IngredientId = 2 },
                new ProductIngredient { ProductId = 3, IngredientId = 3 },
                new ProductIngredient { ProductId = 3, IngredientId = 6 },
                new ProductIngredient { ProductId = 3, IngredientId = 7 },
                new ProductIngredient { ProductId = 3, IngredientId = 8 },
                new ProductIngredient { ProductId = 4, IngredientId = 1 },
                new ProductIngredient { ProductId = 4, IngredientId = 2 },
                new ProductIngredient { ProductId = 4, IngredientId = 3 },
                new ProductIngredient { ProductId = 4, IngredientId = 4 },
                new ProductIngredient { ProductId = 4, IngredientId = 5 },
                new ProductIngredient { ProductId = 4, IngredientId = 6 },
                new ProductIngredient { ProductId = 4, IngredientId = 7 },
                new ProductIngredient { ProductId = 4, IngredientId = 8 },
                new ProductIngredient { ProductId = 5, IngredientId = 1 },
                new ProductIngredient { ProductId = 5, IngredientId = 2 },
                new ProductIngredient { ProductId = 5, IngredientId = 3 },
                new ProductIngredient { ProductId = 5, IngredientId = 4 },
                new ProductIngredient { ProductId = 5, IngredientId = 7 },
                new ProductIngredient { ProductId = 5, IngredientId = 8 },
                new ProductIngredient { ProductId = 6, IngredientId = 1 },
                new ProductIngredient { ProductId = 6, IngredientId = 2 },
                new ProductIngredient { ProductId = 6, IngredientId = 3 },
                new ProductIngredient { ProductId = 6, IngredientId = 4 },
                new ProductIngredient { ProductId = 6, IngredientId = 7 },
                new ProductIngredient { ProductId = 6, IngredientId = 8 },
                new ProductIngredient { ProductId = 7, IngredientId = 1 },
                new ProductIngredient { ProductId = 7, IngredientId = 2 },
                new ProductIngredient { ProductId = 7, IngredientId = 3 },
                new ProductIngredient { ProductId = 7, IngredientId = 4 },
                new ProductIngredient { ProductId = 7, IngredientId = 7 },
                new ProductIngredient { ProductId = 7, IngredientId = 8 },
                new ProductIngredient { ProductId = 8, IngredientId = 1 },
                new ProductIngredient { ProductId = 8, IngredientId = 2 },
                new ProductIngredient { ProductId = 8, IngredientId = 6 },
                new ProductIngredient { ProductId = 9, IngredientId = 1 },
                new ProductIngredient { ProductId = 9, IngredientId = 2 },
                new ProductIngredient { ProductId = 9, IngredientId = 6 },
                new ProductIngredient { ProductId = 10, IngredientId = 1 },
                new ProductIngredient { ProductId = 10, IngredientId = 2 },
                new ProductIngredient { ProductId = 10, IngredientId = 6 },
                new ProductIngredient { ProductId = 11, IngredientId = 1 },
                new ProductIngredient { ProductId = 11, IngredientId = 2 },
                new ProductIngredient { ProductId = 11, IngredientId = 3 },
                new ProductIngredient { ProductId = 11, IngredientId = 4 },
                new ProductIngredient { ProductId = 11, IngredientId = 5 },
                new ProductIngredient { ProductId = 11, IngredientId = 6 },
                new ProductIngredient { ProductId = 11, IngredientId = 7 },
                new ProductIngredient { ProductId = 11, IngredientId = 8 },
                new ProductIngredient { ProductId = 12, IngredientId = 1 },
                new ProductIngredient { ProductId = 12, IngredientId = 2 },
                new ProductIngredient { ProductId = 12, IngredientId = 3 },
                new ProductIngredient { ProductId = 12, IngredientId = 4 },
                new ProductIngredient { ProductId = 12, IngredientId = 5 },
                new ProductIngredient { ProductId = 12, IngredientId = 6 },
                new ProductIngredient { ProductId = 12, IngredientId = 7 },
                new ProductIngredient { ProductId = 12, IngredientId = 8 },
                new ProductIngredient { ProductId = 13, IngredientId = 1 },
                new ProductIngredient { ProductId = 13, IngredientId = 2 },
                new ProductIngredient { ProductId = 13, IngredientId = 3 },
                new ProductIngredient { ProductId = 13, IngredientId = 4 },
                new ProductIngredient { ProductId = 13, IngredientId = 5 },
                new ProductIngredient { ProductId = 13, IngredientId = 6 },
                new ProductIngredient { ProductId = 13, IngredientId = 7 },
                new ProductIngredient { ProductId = 13, IngredientId = 8 }

               );
        }
    }
}
