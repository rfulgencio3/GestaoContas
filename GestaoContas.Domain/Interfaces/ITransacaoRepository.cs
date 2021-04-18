using GestaoContas.Domain.Entities;
using System.Collections.Generic;

namespace GestaoContas.Domain.Interfaces
{
    public interface ITransacaoRepository
    {
        public void Adicionar(Transacao transacao);
        public IEnumerable<Transacao> ObterTodasPorIdentificador();
        public bool ValidaIdentificador(int identificador);
        public void AtualizaSaldo(Transacao transacao);
    }
}
