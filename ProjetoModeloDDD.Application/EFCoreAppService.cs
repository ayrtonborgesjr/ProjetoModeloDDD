using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class EFCoreAppService<T> : IEFCoreAppService<T> where T : class
    {
        private readonly IEFCoreService<T> _service;

        public EFCoreAppService(IEFCoreService<T> service)
        {
            _service = service;
        }

        public async Task<bool> Add(T entity)
        {
            return await _service.Add(entity);
        }

        public async Task<bool> Update(T entity)
        {
            return await _service.Update(entity);
        }

        public async Task<bool> Delete(T entity)
        {
            return await _service.Delete(entity);
        }
    }
}
