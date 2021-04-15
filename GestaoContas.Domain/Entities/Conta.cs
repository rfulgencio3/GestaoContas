using System;

namespace GestaoContas.Domain.Entities
{
    public class Conta
    {
        public Guid CorrentistaId { get; set; }
        public Guid ContaId { get; private set; }
        public string Descricao { get; private set; }
        public Status Status { get; private set; }
        public Tipo Tipo { get; private set; }
        public decimal? Saldo { get; private set; }

        public Correntista Correntista { get; set; }

        public Conta(Guid contaId, string descricao, Status status, Tipo tipo, decimal saldo)
        {
            if (string.IsNullOrEmpty(contaId.ToString()))
            {
                throw new ArgumentException("Informação de código de conta não encontrado.");
            }

            ContaId = contaId;
            Descricao = descricao;
            Status = status;
            Tipo = tipo;
            Saldo = saldo;
        }

        internal void AssociarCorrentista(Guid correntistaId)
        {
            CorrentistaId = correntistaId;
        }
    }
}
