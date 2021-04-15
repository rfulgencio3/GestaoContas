using GestaoContas.Domain.Data;
using GestaoContas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoContas.Domain.Repository
{
    public class ContaRepository
    {
        private readonly GestaoContasDbContext _gestaoContasDbContext;
        public ContaRepository(GestaoContasDbContext gestaoContasDbContext)
        {
            _gestaoContasDbContext = gestaoContasDbContext;
        }

        public void AdicionarConta(Conta conta)
        {
            _gestaoContasDbContext.Contas.Add(conta);
            _gestaoContasDbContext.SaveChanges();
        }
        public IEnumerable<Conta> ObterTodasContas()
        {
            return _gestaoContasDbContext.Contas.ToList();
        }
        public IEnumerable<Conta> ObterContaPorIdentificador(Guid contaId)
        {
            return _gestaoContasDbContext.Contas
                .Where(p => p.ContaId.Equals(contaId))
                .ToList();
        }
        public IEnumerable<Conta> ObterTodasContasPorCorrentista(Guid correntistaId)
        {
            return _gestaoContasDbContext.Contas
                .Where(p => p.CorrentistaId.Equals(correntistaId))
                .ToList();
        }
    }
}
