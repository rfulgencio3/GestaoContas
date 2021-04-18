using GestaoContas.Domain.Data;
using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GestaoContas.Domain.Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly GestaoContasDbContext _gestaoContasDbContext;
        public TransacaoRepository(GestaoContasDbContext gestaoContasDbContext)
        {
            _gestaoContasDbContext = gestaoContasDbContext;
        }

        public void Adicionar(Transacao transacao)
        {
            _gestaoContasDbContext.Transacoes.Add(transacao);
            _gestaoContasDbContext.SaveChanges();
        }

        public bool ValidaIdentificador(int identificador)
        {
            return _gestaoContasDbContext.Correntistas
                .Any(p => p.Identificador == identificador);
        }

        public IEnumerable<Transacao> ObterTodasPorIdentificador()
        {
            return _gestaoContasDbContext.Transacoes.ToList();
        }

        public void AtualizaSaldo(Transacao transacao)
        {
            var saldo = _gestaoContasDbContext.Transacoes
                .Where(p => p.Identificador == transacao.Identificador)
                .Sum(p => p.Valor);

            Conta contaSaldo = new Conta(transacao.Identificador, saldo);
            _gestaoContasDbContext.Contas.Update(contaSaldo);
            _gestaoContasDbContext.SaveChanges();
        }
    }
}
