using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IEFCoreService<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
