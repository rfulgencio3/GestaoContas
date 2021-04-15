using System;
using System.Collections.Generic;

namespace GestaoContas.Domain.Entities
{
    public class Correntista
    {
        public Guid CorrentistaId { get; private set; }
        public string Nome { get; set; }
        public Status Status { get; set; }

        private readonly List<Conta> _contas;
        public IReadOnlyCollection<Conta> Conta => _contas;
        
        protected Correntista() 
        { 
            _contas = new List<Conta>(); 
        }
        public Correntista(Guid correntistaId, string nome, Status status)
        {
            CorrentistaId = correntistaId;
            Nome = nome;
            Status = status;
        }

        public void AdicionarConta(Conta conta)
        {
            ValidaInformacoesConta(conta);
            conta.AssociarCorrentista(CorrentistaId);
        }

        private void ValidaInformacoesConta(Conta conta)
        {
            var contaId = conta.ContaId;
            contaId = !string.IsNullOrEmpty(contaId.ToString()) ? contaId : throw new ArgumentException($"Informação de Conta Inválida.");
        }

        public static class CorrentistaFactory
        {
            public static Correntista NovoCorrentista(Guid correntistaId)
            {
                var correntista = new Correntista
                {
                    CorrentistaId = correntistaId
                };
                correntista.StatusAtivo();
                return correntista;
            }
        }
        private void StatusAtivo()
        {
            Status = Status.ACTIVE;
        }
    }
}
