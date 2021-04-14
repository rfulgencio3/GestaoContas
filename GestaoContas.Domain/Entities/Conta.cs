using System;

namespace GestaoContas.Domain.Entities
{
    public class Conta
    {
        public Guid ContaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Status Status { get; private set; }

        public Conta(Guid contaId, string nome, string descricao, Status status)
        {
            ContaId = contaId;
            Nome = nome;
            Descricao = descricao;
            Status = status;
        }
    }
}
