using GestaoContas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GestaoContas.Domain.Interfaces
{
    public interface IContaRepository
    {
        Conta ObterPorIdentificador(int identificador);
        decimal VerificaSaldoOrigem(int identificadorOrigem);
        void AtualizarSaldos(Transferencia transferencia);
    }
}
