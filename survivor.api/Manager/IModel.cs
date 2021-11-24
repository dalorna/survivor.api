namespace survivor.api.Manager
{
    public interface IModel<TKey>
    {
        TKey Id
        {
            get;
            set;
        }
    }
}
