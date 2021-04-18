using System;

namespace GestaoContas.Domain.Entities
{
    public class Transferencia
    {
        public Guid TransferenciaId { get; private set; }
        public int IdentificadorOrigem { get; set; }
        public int IdentificadorDestino { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDeposito { get; private set; }
        public Transferencia(int identificadorOrigem, int identificadorDestino, decimal valor)
        {
            TransferenciaId = Guid.NewGuid();
            DataDeposito = DateTime.Now;

            IdentificadorOrigem = identificadorOrigem;
            IdentificadorDestino = identificadorDestino;
            Valor = valor;
        }
    }
}
