using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configrutaion
{
    public class OrderIngredientConfig : IEntityTypeConfiguration<OrderIngredient>
    {
        public void Configure(EntityTypeBuilder<OrderIngredient> builder)
        {
            builder.HasKey(x => new { x.OrderDetailId, x.IngredientId });
            builder.HasOne(x => x.OrderDetail).WithMany(x => x.OrderIngredients).HasForeignKey(x => x.OrderDetailId);
            builder.HasOne(x => x.Ingredient).WithMany(x => x.OrderIngredients).HasForeignKey(x => x.IngredientId);
        }
    }
}
