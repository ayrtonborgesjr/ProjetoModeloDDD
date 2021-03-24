using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Infrastructure.Data.Context;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infrastructure.Data.Repositories
{
    public class EFCoreRepository<T> : IEFCoreRepository<T> where T : class
    {        
        protected ProjetoModeloContext _context;

        public EFCoreRepository(ProjetoModeloContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
