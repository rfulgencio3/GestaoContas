using GestaoContas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GestaoContas.Domain.Interfaces
{
    public interface IContaRepository
    {
        void Adicionar(Conta conta);
        IEnumerable<Conta> ObterTodas();
        IEnumerable<Conta> ObterPorIdentificador(Guid contaId);
        IEnumerable<Conta> ObterTodasPorCorrentista(Guid correntistaId);
    }
}
