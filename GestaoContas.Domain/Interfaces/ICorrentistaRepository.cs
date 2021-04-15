using GestaoContas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GestaoContas.Domain.Interfaces
{
    public interface ICorrentistaRepository
    {
        void Adicionar(Correntista correntista);
        IEnumerable<Correntista> ObterTodos();
        IEnumerable<Correntista> ObterPorIdentificador(Guid correntistaId);
        IEnumerable<Correntista> ObterPorNome(string nome);
    }
}
