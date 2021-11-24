using System.Collections.Generic;
using System.Threading.Tasks;

namespace survivor.api.Manager
{
    public interface IManager<TModel, TKey> where TModel : class, IModel<TKey>
    {
        Task<TModel> PutModel(TKey id, TModel model);

        Task<TModel> PostModel(TModel model);

        Task<IEnumerable<TModel>> PostModels(IEnumerable<TModel> models);

        Task<TModel> PatchModel(TKey id, Dictionary<string, object> patch);

        Task<TModel> GetModel(TKey id);

        Task<TModel> GetModelByQuery(string query);

        Task<IEnumerable<TModel>> GetModels();

        Task<IEnumerable<TModel>> GetModels(string query);

        Task<bool> DeleteModel(TKey id);
    }
}
