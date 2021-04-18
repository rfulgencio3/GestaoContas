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
        public Correntista ObterPorIdentificador(Conta conta)
        {
            return _gestaoContasDbContext.Correntistas
                .Where(p => p.Identificador.Equals(conta.Identificador))
                .FirstOrDefault();
        }
    }
}
