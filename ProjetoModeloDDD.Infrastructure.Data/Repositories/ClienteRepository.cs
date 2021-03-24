using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infrastructure.Data.Repositories
{
    public class ClienteRepository : EFCoreRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ProjetoModeloContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            IQueryable<Cliente> query = _context.Clientes.Include(p => p.Produtos);
            query = query.AsNoTracking().OrderBy(h => h.ClienteId);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            IQueryable<Cliente> query = _context.Clientes.Include(p => p.Produtos);

            return await query.AsNoTracking().FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        public async Task<IEnumerable<Cliente>> GetClientesByNome(string nome)
        {
            IQueryable<Cliente> query = _context.Clientes.Include(p => p.Produtos);
            query = query.AsNoTracking().Where(h => h.Nome.Contains(nome)).OrderBy(h => h.ClienteId);

            return await query.ToArrayAsync();
        }
    }
}
