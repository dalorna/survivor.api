using survivor.api.Entity;
using survivor.api.Manager;
using System.Collections.Generic;

namespace survivor.api.Mapper
{
    public interface IMapper<TModel, TEntity, TKey> where TModel : IModel<TKey> where TEntity : IEntity<TKey>
    {
        TEntity ToEntity(TModel model);

        TEntity ToEntity(TModel model, TEntity entity);

        TModel ToModel(TEntity entity);

        TModel ToModel(TEntity entity, TModel model);

        IEnumerable<TModel> ToModels(IEnumerable<TEntity> entities, IEnumerable<TModel> models = null);

        IEnumerable<TEntity> ToEntities(IEnumerable<TModel> models, IEnumerable<TEntity> entities = null);
    }
}
