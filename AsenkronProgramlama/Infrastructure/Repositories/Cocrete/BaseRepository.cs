using AsenkronProgramlama.Infrastructure.Context;
using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AsenkronProgramlama.Infrastructure.Repositories.Cocrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _table;

        //önce context nesnemi almam lazım ctor da di ile alıyorum
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _table=_context.Set<T>();//herkes gidip kendi tablosuna eklenebilir
        }
        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);//AddAsync async çalıştığım için metod dönüşünü async yapmalıyım
            await _context.SaveChangesAsync();
        }
        public async Task<T> GetByDefault(Expression<Func<T, bool>> expression)
        {
            return await _table.FirstOrDefaultAsync(expression);//ilgili şartı sağlayan ilk şartı getir
        }

        public async Task<List<T>> GetByDefaults(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> GetFilter<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
