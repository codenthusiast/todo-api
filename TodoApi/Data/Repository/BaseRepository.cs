using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoApi.Core.Entities;
using TodoApi.Core.Repository;

namespace TodoApi.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity
    {
        protected readonly AppDbContext _dbContext;
        protected DbSet<T> _table = null;
        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await _table.FindAsync(id);
            _table.Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).AsNoTracking().ToListAsync();
        }

        public IQueryable Query(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).AsNoTracking();
        }

        public virtual async  Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _table.AsNoTracking<T>().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
