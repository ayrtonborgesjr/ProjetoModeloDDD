using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ProjetoModeloDDD.Application.Interface
{
    public interface IClienteAppService : IEFCoreAppService<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task<IEnumerable<Cliente>> GetClientesByNome(string nome);
        Task<IEnumerable<Cliente>> ObterClientesEspeciais();

        IEnumerable<SelectListItem> ClienteDropDownList();
    }
}
