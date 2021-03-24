using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IEFCoreRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
