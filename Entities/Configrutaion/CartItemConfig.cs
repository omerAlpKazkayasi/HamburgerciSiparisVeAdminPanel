using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configrutaion
{
    public class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(c => c.CartItemId);

            builder.HasOne(c => c.Cart).WithMany(c => c.CartItems).HasForeignKey(c => c.CartId);

            builder.HasOne(c => c.Product).WithMany(c => c.CartItems).HasForeignKey(c => c.ProductId);

        }
    }
}
