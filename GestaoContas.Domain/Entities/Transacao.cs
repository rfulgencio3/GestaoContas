using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoContas.Domain.Entities
{
    public class Transacao
    {
        public Guid TransacaoId { get; private set; }
        public int Identificador { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; private set; }
        public Transacao(int identificador, decimal valor)
        {
            TransacaoId = Guid.NewGuid();
            DataTransacao = DateTime.Now;

            Identificador = identificador;
            Valor = valor;
        }
    }
}
