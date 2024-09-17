namespace Core.Utils.DAO
{
    public interface IDao<T>
    {
        bool Exist();
        
        void Save(T obj);
        
        T Load();
    }
}