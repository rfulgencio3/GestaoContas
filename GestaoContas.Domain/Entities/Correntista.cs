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
        public string Status { get; set; }

        private readonly List<Conta> _contas;
        public IReadOnlyCollection<Conta> Conta => _contas;
        
        protected Correntista() 
        { 
            _contas = new List<Conta>(); 
        }
        public Correntista(int identificador, string nome, string descricao, string status)
        {
            Identificador = identificador;
            Nome = nome;
            Descricao = descricao;
            Status = status;
        }

        private void ValidaInformacoesConta(Conta conta)
        {
            var contaId = conta.ContaId;
            contaId = !string.IsNullOrEmpty(contaId.ToString()) ? contaId : throw new ArgumentException($"Informação de Conta Inválida.");
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
