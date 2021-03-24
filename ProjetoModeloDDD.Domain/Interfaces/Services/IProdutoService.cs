using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IProdutoService : IEFCoreService<Produto>
    {
        Task<IEnumerable<Produto>> GetAllProdutos();
        Task<Produto> GetProdutoById(int id);
        Task<IEnumerable<Produto>> GetProdutosByNome(string nome);
    }
}
