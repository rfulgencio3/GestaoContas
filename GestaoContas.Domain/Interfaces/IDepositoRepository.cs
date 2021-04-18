using GestaoContas.Domain.Entities;
using System.Collections.Generic;

namespace GestaoContas.Domain.Interfaces
{
    public interface IDepositoRepository
    {
        public void Adicionar(Deposito deposito);
        public void AtualizarSaldo(Deposito deposito);
    }
}
