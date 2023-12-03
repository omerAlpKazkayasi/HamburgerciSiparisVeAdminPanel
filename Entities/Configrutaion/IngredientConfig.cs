using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configrutaion
{
    public class IngredientConfig : IEntityTypeConfiguration<Ingredient>
    {
        public IngredientConfig()
        {
        }

        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.IngredientId);

            builder.HasData(
                new Ingredient
                {
                    IngredientId = 1,
                    IngredientName = "Domates",
                },
                new Ingredient
                {
                    IngredientId = 2,
                    IngredientName = "Marul",
                },
                new Ingredient
                {
                    IngredientId = 3,
                    IngredientName = "Soğan",
                },
                new Ingredient
                {
                    IngredientId = 4,
                    IngredientName = "Turşu",
                },
                new Ingredient
                {
                    IngredientId = 5,
                    IngredientName = "Ketçap",
                },
                new Ingredient
                {
                    IngredientId = 6,
                    IngredientName = "Mayonez",
                },
                new Ingredient
                {
                    IngredientId = 7,
                    IngredientName = "Hardal",
                },
                new Ingredient
                {
                    IngredientId = 8,
                    IngredientName = "BBQ",
                }
                );
        }
    }
}
