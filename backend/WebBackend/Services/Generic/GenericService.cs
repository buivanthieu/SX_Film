using WebBackend.Repositories.Generic;

namespace WebBackend.Services.Generic
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<ICollection<T>> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _repository.Find(predicate);
        }

        public async Task Add(T entity)
        {
            await _repository.Add(entity);
        }

        public async Task Update(T entity)
        {
            await _repository.Update(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
