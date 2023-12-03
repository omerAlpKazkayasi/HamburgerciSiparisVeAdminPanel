using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configrutaion
{
    public class SizeConfig : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(x => x.SizeId);


            builder.HasData(
                               new Size
                               {
                                   SizeId = 1,
                                   SizeName = "Küçük",
                               },
                                              new Size
                                              {
                                                  SizeId = 2,
                                                  SizeName = "Orta",
                                              },
                                                             new Size
                                                             {
                                                                 SizeId = 3,
                                                                 SizeName = "Büyük",
                                                             }
                                                                            );
        }
    }
}
