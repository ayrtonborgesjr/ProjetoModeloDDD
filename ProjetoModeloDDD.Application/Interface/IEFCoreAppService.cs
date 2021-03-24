using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IEFCoreAppService<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
