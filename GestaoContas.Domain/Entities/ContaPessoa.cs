using System;

namespace GestaoContas.Domain.Entities
{
    public class ContaPessoa
    {
        public Guid ContaId { get; private set; }
        public Guid PessoaId { get; private set; }
        public Tipo Tipo { get; private set; }
        public decimal Saldo { get; private set; }
        public Conta Conta { get; set; }

        public ContaPessoa(Guid contaId, Guid pessoaId, Tipo tipo, decimal saldo)
        {
            ContaId = contaId;
            PessoaId = pessoaId;
            Tipo = tipo;
            Saldo = saldo;
        }

        public decimal SaldoConta(Guid contaId, Guid pessoaId)
        {
            //TO-DO Implementar busca do saldo através de consulta via 'EF In Memory'
            decimal saldo;

            return Saldo;
        }
    }
}
