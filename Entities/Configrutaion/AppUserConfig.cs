using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Entities.Configrutaion
{
    //public class UserConfig : IEntityTypeConfiguration<User>
    //{
    //    public void Configure(EntityTypeBuilder<User> builder)
    //    {

    //        builder.HasIndex(x => x.UserName).IsUnique();

    //        builder.HasMany(x => x.Carts).WithOne(x => x.User)
    //        .HasForeignKey(x => x.UserId)
    //            .OnDelete(DeleteBehavior.NoAction);


    //    }
    //}
}
