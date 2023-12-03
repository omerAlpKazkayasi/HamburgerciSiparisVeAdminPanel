using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configrutaion
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);
            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x=>x.UserId);

            //builder.Property(x=>x.OrderDate).HasDefaultValue(DateTime.Now);
        }
    }
}
