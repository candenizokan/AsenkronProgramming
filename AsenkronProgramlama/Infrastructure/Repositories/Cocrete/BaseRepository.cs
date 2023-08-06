using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Abstract;

namespace AsenkronProgramlama.Infrastructure.Repositories.Cocrete
{
    public class BaseRepository<T>:IBaseRepository<T> where T : BaseEntity
    {
    }
}
