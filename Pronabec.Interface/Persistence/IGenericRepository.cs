namespace Pronabec.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}