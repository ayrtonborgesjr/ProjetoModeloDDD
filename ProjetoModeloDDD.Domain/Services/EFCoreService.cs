using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class EFCoreService<T> : IEFCoreService<T> where T : class
    {
        private readonly IEFCoreRepository<T> _repository;

        public EFCoreService(IEFCoreRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Add(T entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<bool> Update(T entity)
        {
            return await _repository.Update(entity);
        }

        public async Task<bool> Delete(T entity)
        {
            return await _repository.Delete(entity);
        }
    }
}
