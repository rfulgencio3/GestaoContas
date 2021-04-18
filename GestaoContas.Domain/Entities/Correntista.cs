using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestaoContas.Domain.Entities
{
    public class Correntista
    {
        [Key]
        public int Identificador { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }
        
        protected Correntista() 
        { 
        }
        public Correntista(int identificador, string nome, string descricao, Status status)
        {
            Identificador = identificador;
            Nome = nome;
            Descricao = descricao;
            Status = status;
        }
        public static class CorrentistaFactory
        {
            public static Correntista NovoCorrentista(int identificador)
            {
                var correntista = new Correntista
                {
                    Identificador = identificador
                };
                return correntista;
            }
        }
    }
}
