using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoContas.Domain.Entities
{
    public class Conta
    {
        [Key]
        public int Identificador { get; set; }
        public decimal Saldo { get; set; }
        public Correntista Correntista { get; private set; }

        public Conta(int identificador, decimal saldo)
        {
            Identificador = identificador;
            Saldo = saldo;
        }
    }
}
