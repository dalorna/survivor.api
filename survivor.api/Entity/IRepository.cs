using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace survivor.api.Entity
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        DbContext Context
        {
            get;
        }

        Task<bool> SaveChangesAsync();

        Task<TEntity> CreateEntity(TEntity entity);

        Task<IEnumerable<TEntity>> CreateEntities(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateEntity(TEntity entity);

        Task<IEnumerable<TEntity>> UpdateEntities(IEnumerable<TEntity> entities);

        Task<TEntity> RetrieveEntity(TKey id);

        Task<TEntity> RetrieveEntity(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> RetrieveEntityByQuery(string query);

        Task<IEnumerable<TEntity>> RetrieveEntities(IEnumerable<TKey> ids);

        Task<IEnumerable<TEntity>> RetrieveEntities(Expression<Func<TEntity, bool>> predicate = null);

        Task<IEnumerable<TEntity>> RetrieveEntities(string query);

        Task<bool> DeleteEntity(TKey id);

        Task<bool> DeleteEntities(IEnumerable<TKey> ids);
    }
}
