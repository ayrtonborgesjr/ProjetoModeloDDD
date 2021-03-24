using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IEFCoreRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task<IEnumerable<Cliente>> GetClientesByNome(string nome);
    }
}
