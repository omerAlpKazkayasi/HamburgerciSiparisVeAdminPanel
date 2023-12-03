using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configrutaion
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);


            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Menü",
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Hamburger",
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "İçecek",
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Yan Ürünler",
                }
                );
        }
    }
}
