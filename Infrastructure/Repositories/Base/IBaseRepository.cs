﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestGAP.Infrastructure.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindByIdAsync(object id);
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task Remove(object id);

        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetPageAsync(int page, int pageSize);  
    }
}
