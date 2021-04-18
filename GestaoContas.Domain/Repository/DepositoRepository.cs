using GestaoContas.Domain.Data;
using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GestaoContas.Domain.Repository
{
    public class DepositoRepository : IDepositoRepository
    {
        private readonly GestaoContasDbContext _gestaoContasDbContext;
        public DepositoRepository(GestaoContasDbContext gestaoContasDbContext)
        {
            _gestaoContasDbContext = gestaoContasDbContext;
        }

        public void Adicionar(Deposito deposito)
        {
            _gestaoContasDbContext.Depositos.Add(deposito);
            _gestaoContasDbContext.SaveChanges();
        }

        public bool ValidaIdentificador(int identificador)
        {
            return _gestaoContasDbContext.Correntistas
                .Any(p => p.Identificador == identificador);
        }

        public IEnumerable<Deposito> ObterTodosPorIdentificador()
        {
            return _gestaoContasDbContext.Depositos.ToList();
        }

        public void AtualizaSaldo(Deposito deposito)
        {
            var saldo = _gestaoContasDbContext.Depositos
                .Where(p => p.Identificador == deposito.Identificador)
                .Sum(p => p.Valor);

            Conta contaSaldo = new Conta(deposito.Identificador, saldo);
            _gestaoContasDbContext.Contas.Update(contaSaldo);
            _gestaoContasDbContext.SaveChanges();
        }
    }
}
