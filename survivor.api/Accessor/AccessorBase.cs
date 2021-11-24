using survivor.api.Entity;
using survivor.api.Manager;
using survivor.api.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survivor.api.Accessor
{
    public abstract class AccessorBase<TModel, TEntity, TRepository, TKey> : IAccessor<TModel, TKey> where TModel : class, IModel<TKey>, new() where TEntity : class, IEntity<TKey>, new() where TRepository : class, IRepository<TEntity, TKey>
    {
        protected TRepository _repository;

        protected IMapper<TModel, TEntity, TKey> _mapper;

        public AccessorBase(TRepository repository, IMapper<TModel, TEntity, TKey> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual Task<TModel> PutModel(TKey id, TModel model)
        {
            if (id != null && !id.Equals(null))
            {
                return UpdateModel(model);
            }

            return CreateModel(model);
        }

        public virtual async Task<TModel> PostModel(TModel model)
        {
            return await UpdateModel(model);
        }

        public virtual async Task<IEnumerable<TModel>> PostModels(IEnumerable<TModel> models)
        {
            IEnumerable<TKey> ids = models.Select((TModel x) => x.Id);
            IEnumerable<TEntity> entities = await _repository.RetrieveEntities((TEntity x) => ids.Contains(x.Id));
            List<TEntity> newEntities = new List<TEntity>();
            List<TEntity> updateEntities = new List<TEntity>();
            Parallel.ForEach(models, delegate (TModel m)
            {
                TEntity val = entities.FirstOrDefault((TEntity x) => x.Id.Equals(m.Id));
                if (val == null)
                {
                    newEntities.Add(_mapper.ToEntity(m));
                }
                else
                {
                    updateEntities.Add(_mapper.ToEntity(m, val));
                }
            });
            if (newEntities.Any())
            {
                await _repository.CreateEntities(newEntities);
            }

            if (updateEntities.Any())
            {
                await _repository.UpdateEntities(updateEntities);
            }

            await _repository.SaveChangesAsync();
            newEntities.AddRange(updateEntities);
            return _mapper.ToModels(newEntities, models).ToList();
        }

        public virtual async Task<TModel> CreateModel(TModel model)
        {
            TEntity entity2 = _mapper.ToEntity(model);
            entity2 = await _repository.CreateEntity(entity2);
            await _repository.SaveChangesAsync();
            return _mapper.ToModel(entity2, model);
        }

        public virtual async Task<TModel> UpdateModel(TModel model)
        {
            TEntity entity3 = await _repository.RetrieveEntity((TEntity x) => x.Id.Equals(model.Id));
            if (entity3 == null)
            {
                entity3 = _mapper.ToEntity(model, entity3);
                entity3 = await _repository.CreateEntity(entity3);
            }
            else
            {
                _mapper.ToEntity(model, entity3);
                entity3 = await _repository.UpdateEntity(entity3);
            }

            await _repository.SaveChangesAsync();
            return _mapper.ToModel(entity3, model);
        }

        public virtual async Task<TModel> PatchModel(TKey id, IDictionary<string, object> patch)
        {
            TEntity val = await _repository.RetrieveEntity(id);
            if (val == null)
            {
                throw new Exception("Entity Not Found");
            }

            val = await _repository.UpdateEntity(val);
            return _mapper.ToModel(val);
        }

        public virtual async Task<TModel> GetModel(TKey id)
        {
            TEntity entity = await _repository.RetrieveEntity(id);
            return _mapper.ToModel(entity);
        }

        public virtual async Task<TModel> GetModelByQuery(string query)
        {
            TEntity entity = await _repository.RetrieveEntityByQuery(query);
            return _mapper.ToModel(entity);
        }

        public virtual async Task<IEnumerable<TModel>> GetModels()
        {
            IEnumerable<TEntity> entities = await _repository.RetrieveEntities();
            return _mapper.ToModels(entities);
        }

        public virtual async Task<IEnumerable<TModel>> GetModels(IEnumerable<TKey> ids)
        {
            IEnumerable<TEntity> entities = await _repository.RetrieveEntities(ids);
            return _mapper.ToModels(entities);
        }

        public virtual async Task<IEnumerable<TModel>> GetModels(string query)
        {
            IEnumerable<TEntity> entities = await _repository.RetrieveEntities(query);
            return _mapper.ToModels(entities);
        }

        public virtual async Task<bool> DeleteModel(TKey id)
        {
            return await _repository.DeleteEntity(id);
        }
    }
}
