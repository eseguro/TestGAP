using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestGAP.Infrastructure.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetPageAsync(int page, int pageSize);  
    }
}
