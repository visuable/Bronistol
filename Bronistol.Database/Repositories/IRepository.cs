using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bronistol.Database.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(Expression<Func<TEntity, bool>> expression);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> FirstAsync();
    }
}