using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseManager.Application.Interfaces
{
    public interface IRepositoryAsync<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task RemoveAsync(TEntity entity);

        Task RemoveRangeAsync(IEnumerable<TEntity> entities);

        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);

        Task<int> GetCountAsync();

        Task<IEnumerable<TEntity>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    }
}