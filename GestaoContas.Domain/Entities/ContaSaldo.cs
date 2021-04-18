using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoContas.Domain.Entities
{
    public class ContaSaldo
    {
        public int Identificador { get; set; }
        public decimal Saldo { get; set; }

        private readonly List<Transacao> _transacoes;
        public IReadOnlyCollection<Transacao> Transacoes => _transacoes;
        public ContaSaldo(int identificador, decimal saldo)
        {
            Identificador = identificador;
            Saldo = saldo;
        }
    }
}
