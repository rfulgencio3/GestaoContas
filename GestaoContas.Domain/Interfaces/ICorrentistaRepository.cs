using GestaoContas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GestaoContas.Domain.Interfaces
{
    public interface ICorrentistaRepository
    {
        void Adicionar(Correntista correntista);
        void Atualizar(Correntista correntista);
        void Excluir(Correntista correntista);
        void InserirSaldo(int identificador);
        IEnumerable<Correntista> ObterTodos();
        Correntista ObterPorIdentificador(int identificador);
        IEnumerable<Correntista> ObterPorNome(string nome);
        bool Existe(int identificador);
    }
}
