using GestaoContas.Domain.Data;
using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoContas.Domain.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly GestaoContasDbContext _gestaoContasDbContext;
        public ContaRepository(GestaoContasDbContext gestaoContasDbContext)
        {
            _gestaoContasDbContext = gestaoContasDbContext;
        }

        public void Adicionar(Conta conta)
        {
            _gestaoContasDbContext.Contas.Add(conta);
            _gestaoContasDbContext.SaveChanges();
        }
        public IEnumerable<Conta> ObterTodas()
        {
            return _gestaoContasDbContext.Contas.ToList();
        }
        public IEnumerable<Conta> ObterPorIdentificador(Guid contaId)
        {
            return _gestaoContasDbContext.Contas
                .Where(p => p.ContaId.Equals(contaId))
                .ToList();
        }
        public IEnumerable<Conta> ObterTodasPorCorrentista(Guid correntistaId)
        {
            return _gestaoContasDbContext.Contas
                .Where(p => p.CorrentistaId.Equals(correntistaId))
                .ToList();
        }
    }
}
