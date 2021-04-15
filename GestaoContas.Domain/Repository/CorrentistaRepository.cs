using GestaoContas.Domain.Data;
using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoContas.Domain.Repository
{
    public class CorrentistaRepository : ICorrentistaRepository
    {
        private readonly GestaoContasDbContext _gestaoContasDbContext;
        public CorrentistaRepository(GestaoContasDbContext gestaoContasDbContext)
        {
            _gestaoContasDbContext = gestaoContasDbContext;
        }

        public void AdicionarCorrentista(Correntista correntista)
        {
            _gestaoContasDbContext.Correntistas.Add(correntista);
            _gestaoContasDbContext.SaveChanges();
        }
        public IEnumerable<Correntista> ObterTodosCorrentistas()
        {
            return _gestaoContasDbContext.Correntistas.ToList();
        }
        public IEnumerable<Correntista> ObterCorrentistaPorIdentificador(Guid correntistaId)
        {
            return _gestaoContasDbContext.Correntistas
                .Where(p => p.CorrentistaId.Equals(correntistaId))
                .ToList();
        }
        public IEnumerable<Correntista> ObterCorrentistaPorNome(string nome)
        {
            return _gestaoContasDbContext.Correntistas
                .Where(p => p.Nome.Equals(nome))
                .ToList();
        }

    }
}
