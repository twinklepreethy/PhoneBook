namespace PhoneBookAPI.Repository
{
    public interface IBaseRepository<T> where T : TEntity
    {
        Task<List<T>> GetAll();
        Task Delete(Guid id);
        Task Add(T entity);
        Task Update(T entity);
    }
}