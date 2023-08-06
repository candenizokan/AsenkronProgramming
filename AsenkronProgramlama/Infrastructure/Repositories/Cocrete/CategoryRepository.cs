using AsenkronProgramlama.Infrastructure.Context;
using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Concrete;

namespace AsenkronProgramlama.Infrastructure.Repositories.Cocrete
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
