using survivor.api.Accessor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace survivor.api.Manager
{
    public abstract class ManagerBase<TModel, TAccessor, TKey> : IManager<TModel, TKey> where TModel : class, IModel<TKey> where TAccessor : IAccessor<TModel, TKey>
    {
        protected TAccessor accessor
        {
            get;
            set;
        }

        public ManagerBase(TAccessor accessor)
        {
            this.accessor = accessor;
        }

        public virtual async Task<TModel> PutModel(TKey id, TModel model)
        {
            try
            {
                return await accessor.PutModel(id, model);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TModel> PostModel(TModel model)
        {
            try
            {
                return await accessor.PostModel(model);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TModel>> PostModels(IEnumerable<TModel> models)
        {
            try
            {
                return await accessor.PostModels(models);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TModel> PatchModel(TKey id, Dictionary<string, object> patch)
        {
            try
            {
                return await accessor.PatchModel(id, patch);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TModel> GetModel(TKey id)
        {
            try
            {
                return await accessor.GetModel(id);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TModel> GetModelByQuery(string query)
        {
            try
            {
                return await accessor.GetModelByQuery(query);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TModel>> GetModels()
        {
            try
            {
                return await accessor.GetModels();
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<IEnumerable<TModel>> GetModels(string query)
        {
            try
            {
                return await accessor.GetModels(query);
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<bool> DeleteModel(TKey id)
        {
            try
            {
                return await accessor.DeleteModel(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
