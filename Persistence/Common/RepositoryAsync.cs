using CourseManager.Application.Interfaces;
using CourseManager.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseManager.Persistence.Common
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            await SaveAsync();
        }

        public virtual IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> condition)
        {
            return _dbContext.Set<TEntity>().Where(condition).AsNoTracking();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<TEntity>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await SaveAsync();
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
            await SaveAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
            await SaveAsync();
        }

        public virtual async Task<int> GetCountAsync()
        {
            return await _dbContext.Set<TEntity>().CountAsync();
        }

        protected virtual async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}