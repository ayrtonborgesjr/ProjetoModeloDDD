using ProjetoModeloDDD.Domain.Entities; 
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ProdutoService : EFCoreService<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Task<IEnumerable<Produto>> GetAllProdutos()
        {
            return _produtoRepository.GetAllProdutos();
        }

        public Task<Produto> GetProdutoById(int id)
        {
            return _produtoRepository.GetProdutoById(id);
        }

        public Task<IEnumerable<Produto>> GetProdutosByNome(string nome)
        {
            return _produtoRepository.GetProdutosByNome(nome);
        }
    }
}
