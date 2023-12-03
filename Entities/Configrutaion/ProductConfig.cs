using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configrutaion
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.HasOne(x=>x.Category).WithMany(x => x.Products).HasForeignKey(x=>x.CategoryId);
            builder.HasOne(x => x.Size).WithMany(x => x.Products).HasForeignKey(x => x.SizeId);

            builder.HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Big King",
                    Price = 50,
                    CategoryId = 2,
                    ImagePath = "https://www.meatpoultry.com/ext/resources/MPImages/01-2019/011419/burger-king-big-king-xl.jpg?height=690&t=1547844197&width=690"
                },
                 new Product
                 {
                     ProductId = 2,
                     ProductName = "King Chicken",
                     Price = 50,
                     CategoryId = 2,
                     ImagePath = "https://i11.haber7.net//haber/haber7/photos/2022/04/JozAc_1643016662_672.jpg"
                 },
                  new Product
                  {
                      ProductId = 3,
                      ProductName = "Cheese Burger",
                      Price = 50,
                      CategoryId = 2,
                      ImagePath = "https://scontent.fsaw3-1.fna.fbcdn.net/v/t1.6435-9/118476354_625089371711845_2916870861001443404_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=c2f564&_nc_ohc=QBBQh0dPGXYAX9XQeq6&_nc_oc=AQniBnoWdiI9htzuyhm9bLfmDbwXRGsF46CKj5tGMHMPSvHj1-Fdc6N2WDo2Cq8aOjY&_nc_ht=scontent.fsaw3-1.fna&oh=00_AfDmazTiUzJPcRu2x87ZE0FDSpBh1CQG9u945Jhfsjr-JQ&oe=65804BA6"
                  },
                  new Product
                  {
                      ProductId = 4,
                      ProductName = "Whopper Burger",
                      Price = 50,
                      CategoryId = 2,
                      ImagePath = "https://media.istockphoto.com/id/1309352410/tr/foto%C4%9Fraf/ah%C5%9Fap-tahta-%C3%BCzerinde-domates-ve-marul-ile-%C3%A7izburger.jpg?s=612x612&w=0&k=20&c=T_95-FkIT_MeNDK6WrHwQDXRpdT7tdsW3iPTtFxoL4Y="
                  },

                 new Product
                 {
                     ProductId = 5,
                     ProductName = "Whopper Menü",
                     Price = 70,
                     CategoryId = 1,
                     SizeId = 1,
                     ImagePath = "https://koctas-img.mncdn.com/mnpadding/1200/1200/ffffff/productimages/5000061098/5000061098_1_MC/8875210145842_1686903008750.jpg"
                 },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Whopper Menü",
                    Price = 80,
                    CategoryId = 1,
                    SizeId = 2,
                    ImagePath = "https://koctas-img.mncdn.com/mnpadding/1200/1200/ffffff/productimages/5000061098/5000061098_1_MC/8875210145842_1686903008750.jpg"
                },
                new Product
                {
                    ProductId = 7,
                    ProductName = "Whopper Menü",
                    Price = 90,
                    CategoryId = 1,
                    SizeId = 3,
                    ImagePath = "https://koctas-img.mncdn.com/mnpadding/1200/1200/ffffff/productimages/5000061098/5000061098_1_MC/8875210145842_1686903008750.jpg"
                },

                new Product
                {
                    ProductId = 8,
                    ProductName = "King Chicken Menü",
                    Price = 60,
                    CategoryId = 1,
                    SizeId = 1,
                    ImagePath = "https://nova.menuqrkod.com/wp-content/uploads/2023/05/Fast_food_French_fries_Beer_Hamburger_Highball_524931_3840x2160-scaled.jpg"
                },
                new Product
                {
                    ProductId = 9,
                    ProductName = "King Chicken Menü",
                    Price = 70,
                    CategoryId = 1,
                    SizeId = 2,
                    ImagePath = "https://nova.menuqrkod.com/wp-content/uploads/2023/05/Fast_food_French_fries_Beer_Hamburger_Highball_524931_3840x2160-scaled.jpg"
                },
                new Product
                {
                    ProductId = 10,
                    ProductName = "King Chicken Menü",
                    Price = 80,
                    CategoryId = 1,
                    SizeId = 3,
                    ImagePath = "https://nova.menuqrkod.com/wp-content/uploads/2023/05/Fast_food_French_fries_Beer_Hamburger_Highball_524931_3840x2160-scaled.jpg"
                },

                 new Product
                 {
                     ProductId = 11,
                     ProductName = "FÖHM Menü",
                     Price = 100,
                     CategoryId = 1,
                     SizeId = 1,
                     ImagePath = "https://iahbr.tmgrup.com.tr/album/2019/05/12/kansere-sebep-olan-besinler-hangileri-1557653689109.jpg"
                 },
                new Product
                {
                    ProductId = 12,
                    ProductName = "FÖHM Menü",
                    Price = 120,
                    CategoryId = 1,
                    SizeId = 2,
                    ImagePath = "https://iahbr.tmgrup.com.tr/album/2019/05/12/kansere-sebep-olan-besinler-hangileri-1557653689109.jpg"
                },
                new Product
                {
                    ProductId = 13,
                    ProductName = "FÖHM Menü",
                    Price = 140,
                    CategoryId = 1,
                    SizeId = 3,
                    ImagePath = "https://iahbr.tmgrup.com.tr/album/2019/05/12/kansere-sebep-olan-besinler-hangileri-1557653689109.jpg"
                },

                new Product
                {
                    ProductId = 14,
                    ProductName = "Patates Kızartması",
                    Price = 15,
                    CategoryId = 4,
                    ImagePath = "https://img.ekonomim.com/storage/files/images/2023/05/05/patates-kizartma-SPOf_cover.jpg"
                },

                new Product
                {
                    ProductId = 15,
                    ProductName = "Soğan Halkası",
                    Price = 20,
                    CategoryId = 4,
                    ImagePath = "https://www.cumhuriyet.com.tr/Archive/2023/9/9/2117608/kapak_185057.jpg"
                },
                 new Product
                 {
                     ProductId = 16,
                     ProductName = "Çıtır Tavuk",
                     Price = 30,
                     CategoryId = 4,
                     ImagePath = "https://yemek.com/_next/image/?url=https%3A%2F%2Fcdn.yemek.com%2Fmnresize%2F1250%2F833%2Fuploads%2F2022%2F12%2Fcitir-tavuk-sevim.jpg&w=1920&q=75"
                 },

                   new Product
                   {
                       ProductId = 17,
                       ProductName = "Nugget",
                       Price = 30,
                       CategoryId = 4,
                       ImagePath = "https://www.ardaninmutfagi.com/wp-content/uploads/2022/05/tavuk-nugget-i7.jpg"
                   },

                 new Product
                 {
                     ProductId = 18,
                     ProductName = "Cola",
                     Price = 20,
                     CategoryId = 3,
                     SizeId = 1,
                     ImagePath = "https://canaciktim.com/uploads/urun/5ecd2186ba534_kutu-kola.jpg"
                 },
                new Product
                {
                    ProductId = 19,
                    ProductName = "Cola",
                    Price = 25,
                    CategoryId = 3,
                    SizeId = 2,
                    ImagePath = "https://canaciktim.com/uploads/urun/5ecd2186ba534_kutu-kola.jpg"
                },
                new Product
                {
                    ProductId = 20,
                    ProductName = "Cola",
                    Price = 30,
                    CategoryId = 3,
                    SizeId = 3,
                    ImagePath = "https://canaciktim.com/uploads/urun/5ecd2186ba534_kutu-kola.jpg"
                },
                  new Product
                  {
                      ProductId = 21,
                      ProductName = "Fanta",
                      Price = 20,
                      CategoryId = 3,
                      SizeId = 1,
                      ImagePath = "https://canaciktim.com/uploads/urun/5ecd21cf95086_fanta.jpg"
                  },
                new Product
                {
                    ProductId = 22,
                    ProductName = "Fanta",
                    Price = 25,
                    CategoryId = 3,
                    SizeId = 2,
                    ImagePath = "https://canaciktim.com/uploads/urun/5ecd21cf95086_fanta.jpg"
                },
                new Product
                {
                    ProductId = 23,
                    ProductName = "Fanta",
                    Price = 30,
                    CategoryId = 3,
                    SizeId = 3,
                    ImagePath = "https://canaciktim.com/uploads/urun/5ecd21cf95086_fanta.jpg"
                }
                );


        }
    }
}
