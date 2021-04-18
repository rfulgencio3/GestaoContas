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
        public Conta ObterPorIdentificador(int identificador)
        {
            return _gestaoContasDbContext.Contas.FirstOrDefault(p => p.Identificador == identificador);
        }
    }
}
