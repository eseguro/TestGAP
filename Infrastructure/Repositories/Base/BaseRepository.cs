using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestGAP.Infrastructure.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        protected string GetPrimaryKeyName()
        {
            var keyNames = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select(x => x.Name);
            string keyName = keyNames.FirstOrDefault();

            return keyName;
        }

        protected object CastPrimaryKey(object id)
        {
            string keyName = GetPrimaryKeyName();
            Type keyType = typeof(TEntity).GetProperty(keyName).PropertyType;
            return Convert.ChangeType(id, keyType);
        }

        public virtual async Task<TEntity> FindByIdAsync(object id)
        {
            var newId = CastPrimaryKey(id);
            return await _context.FindAsync<TEntity>(newId);
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).FirstOrDefault();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            return entity;
        }
        
        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual async Task<IEnumerable<TEntity>> GetPageAsync(int page, int pageSize)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (page != -1)
                query = query.Skip((page - 1) * pageSize);

            if (pageSize != -1)
                query = query.Take(pageSize);

            return await query.ToListAsync();
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }
    }
}
