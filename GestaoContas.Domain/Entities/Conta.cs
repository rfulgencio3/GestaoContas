using System.ComponentModel.DataAnnotations;

namespace GestaoContas.Domain.Entities
{
    public class Conta
    {
        [Key]
        public int Identificador { get; set; }
        public decimal Saldo { get; set; }
        public Conta(int identificador, decimal saldo)
        {
            Identificador = identificador;
            Saldo = saldo;
        }
    }
}
