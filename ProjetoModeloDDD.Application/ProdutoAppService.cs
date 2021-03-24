using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class ProdutoAppService : EFCoreAppService<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService) : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public Task<IEnumerable<Produto>> GetAllProdutos()
        {
            return _produtoService.GetAllProdutos();
        }

        public Task<Produto> GetProdutoById(int id)
        {
            return _produtoService.GetProdutoById(id);
        }

        public Task<IEnumerable<Produto>> GetProdutosByNome(string nome)
        {
            return _produtoService.GetProdutosByNome(nome);
        }
    }
}
