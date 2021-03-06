using GestaoContas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoContas.Domain.Data
{
    public class GestaoContasDbContext : DbContext
    {
        public DbSet<Correntista> Correntistas { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }

        public GestaoContasDbContext(DbContextOptions<GestaoContasDbContext> options) : base(options) { }
    }
}
