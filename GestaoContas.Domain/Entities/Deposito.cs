using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoContas.Domain.Entities
{
    public class Deposito
    {
        public Guid DepositoId { get; private set; }
        public int Identificador { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDeposito { get; private set; }
        public Deposito(int identificador, decimal valor)
        {
            DepositoId = Guid.NewGuid();
            DataDeposito = DateTime.Now;

            Identificador = identificador;
            Valor = valor;
        }
    }
}
