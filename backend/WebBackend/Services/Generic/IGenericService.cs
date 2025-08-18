using System.Linq.Expressions;

namespace WebBackend.Services.Generic
{
    public interface IGenericService<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T?> GetById(int id);
        Task<ICollection<T>> Find(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}