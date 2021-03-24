using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IProdutoAppService : IEFCoreAppService<Produto>
    {
        Task<IEnumerable<Produto>> GetAllProdutos();
        Task<Produto> GetProdutoById(int id);
        Task<IEnumerable<Produto>> GetProdutosByNome(string nome);

    }
}
