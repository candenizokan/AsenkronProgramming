using AsenkronProgramlama.Infrastructure.Context;
using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Concrete;

namespace AsenkronProgramlama.Infrastructure.Repositories.Cocrete
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext context):base(context)
        {//atasına gönderiyor base'e iş yaptırmak için

        }
    }
}
