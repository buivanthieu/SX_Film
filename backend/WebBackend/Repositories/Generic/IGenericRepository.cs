namespace WebBackend.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T?> GetById(int id);
        Task<ICollection<T>> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}