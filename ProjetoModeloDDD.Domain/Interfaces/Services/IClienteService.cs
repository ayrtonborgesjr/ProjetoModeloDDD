using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IClienteService : IEFCoreService<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task<IEnumerable<Cliente>> GetClientesByNome(string nome);

        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
    }
}
