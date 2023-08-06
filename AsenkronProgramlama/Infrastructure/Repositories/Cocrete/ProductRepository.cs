using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Concrete;

namespace AsenkronProgramlama.Infrastructure.Repositories.Cocrete
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
    }
}
