using GestaoContas.Domain.Data;
using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public void Adicionar(Correntista correntista)
        {
            _gestaoContasDbContext.Correntistas.Add(correntista);
            _gestaoContasDbContext.SaveChanges();
            InserirSaldo(correntista.Identificador);
        }

        public void InserirSaldo(int identificador)
        {
            var saldo = 0.00M;
            Conta contaSaldo = new Conta(identificador, saldo);
            _gestaoContasDbContext.Contas.Add(contaSaldo);
            _gestaoContasDbContext.SaveChanges();
        }
        public void Excluir(Correntista correntista)
        {
            _gestaoContasDbContext.Correntistas.Remove(correntista);
            _gestaoContasDbContext.SaveChanges();
        }
        public IEnumerable<Correntista> ObterTodos()
        {
            return _gestaoContasDbContext.Correntistas.ToList();
        }
        public Correntista ObterPorIdentificador(int identificador)
        {
            return _gestaoContasDbContext.Correntistas
                .Where(p => p.Identificador.Equals(identificador))
                .FirstOrDefault();
        }
        public IEnumerable<Correntista> ObterPorNome(string nome)
        {
            return _gestaoContasDbContext.Correntistas
                .Where(p => p.Nome.Equals(nome))
                .ToList();
        }
        public void Atualizar(Correntista correntista)
        {
            _gestaoContasDbContext.Attach(correntista);
            _gestaoContasDbContext.Entry(correntista).State = EntityState.Modified;
            _gestaoContasDbContext.SaveChanges();

        }
        public bool Existe(int identificador)
        {
            return _gestaoContasDbContext.Correntistas
                .Any(p => p.Identificador == identificador);
        }
    }
}
