using AsenkronProgramlama.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AsenkronProgramlama.Models.Mapping
{
    public class ProductMapping:IEntityTypeConfiguration<Product>//IEntityTypeConfiguration için nugetten Microsoft.EntityFrameworkCore.SqlServer indirmem gerekiyor gitmişken Microsoft.EntityFrameworkCore.Tools da indiriyorum ki migrationu başlatayım
    {
    }
}
