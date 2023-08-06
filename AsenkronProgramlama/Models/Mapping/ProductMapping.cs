using AsenkronProgramlama.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsenkronProgramlama.Models.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>//IEntityTypeConfiguration için nugetten Microsoft.EntityFrameworkCore.SqlServer indirmem gerekiyor gitmişken Microsoft.EntityFrameworkCore.Tools da indiriyorum ki migrationu başlatayım
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(a => a.Category).WithMany(a => a.Products).HasForeignKey(a => a.CategoryId); //bir ürünün bir kategorisi vardır. şidmi gidip db contetimi oluşturabilirim.
        }
    }
}
