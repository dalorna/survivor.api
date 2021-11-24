namespace survivor.api.Entity
{
    public interface IEntity<TKey>
    {
        TKey Id
        {
            get;
            set;
        }
    }
}
