using GestaoContas.Domain.Entities;
using System.Collections.Generic;

namespace GestaoContas.Domain.Interfaces
{
    public interface IDepositoRepository
    {
        public void Adicionar(Deposito deposito);
        public IEnumerable<Deposito> ObterTodosPorIdentificador();
        public bool ValidaIdentificador(int identificador);
        public void AtualizaSaldo(Deposito deposito);
    }
}
