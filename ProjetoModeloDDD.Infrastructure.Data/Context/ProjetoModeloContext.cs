using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infrastructure.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext(DbContextOptions<ProjetoModeloContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produto>().Property(p => p.Valor).HasColumnType("decimal(18,4)");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
