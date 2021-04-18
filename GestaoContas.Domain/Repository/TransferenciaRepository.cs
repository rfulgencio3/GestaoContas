using GestaoContas.Domain.Data;
using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using System.Linq;

namespace GestaoContas.Domain.Repository
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly GestaoContasDbContext _gestaoContasDbContext;
        public TransferenciaRepository(GestaoContasDbContext gestaoContasDbContext)
        {
            _gestaoContasDbContext = gestaoContasDbContext;
        }
        public void Adicionar(Transferencia transferencia)
        {
            _gestaoContasDbContext.Transferencias.Add(transferencia);
            _gestaoContasDbContext.SaveChanges();
        }
    }
}
