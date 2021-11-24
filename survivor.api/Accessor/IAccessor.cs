using survivor.api.Manager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace survivor.api.Accessor
{
    public interface IAccessor<TModel, TKey> where TModel : IModel<TKey>
    {
        Task<TModel> GetModel(TKey id);

        Task<TModel> GetModelByQuery(string query);

        Task<IEnumerable<TModel>> GetModels(string query);

        Task<IEnumerable<TModel>> GetModels();

        Task<TModel> PutModel(TKey id, TModel model);

        Task<TModel> PostModel(TModel model);

        Task<IEnumerable<TModel>> PostModels(IEnumerable<TModel> models);

        Task<TModel> PatchModel(TKey id, IDictionary<string, object> patch);

        Task<bool> DeleteModel(TKey id);
    }
}
