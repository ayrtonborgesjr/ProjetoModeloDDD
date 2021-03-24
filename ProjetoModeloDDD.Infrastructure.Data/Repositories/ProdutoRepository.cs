using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : EFCoreRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProjetoModeloContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Produto>> GetAllProdutos()
        {
            IQueryable<Produto> query = _context.Produtos.Include(p => p.Cliente);
            query = query.AsNoTracking().OrderBy(h => h.ProdutoId);

            return await query.ToArrayAsync();
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            IQueryable<Produto> query = _context.Produtos.Include(p => p.Cliente);

            return await query.AsNoTracking().FirstOrDefaultAsync(p => p.ProdutoId == id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosByNome(string nome)
        {
            IQueryable<Produto> query = _context.Produtos.Include(p => p.Cliente);
            query = query.AsNoTracking().Where(h => h.Nome.Contains(nome)).OrderBy(h => h.ClienteId);

            return await query.ToArrayAsync();
        }
    }
}
