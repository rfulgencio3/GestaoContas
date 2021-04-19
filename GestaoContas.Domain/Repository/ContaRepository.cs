using GestaoContas.Domain.Data;
using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using System.Linq;

namespace GestaoContas.Domain.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly GestaoContasDbContext _gestaoContasDbContext;
        public ContaRepository(GestaoContasDbContext gestaoContasDbContext)
        {
            _gestaoContasDbContext = gestaoContasDbContext;
        }
        public Conta ObterPorIdentificador(int identificador)
        {
            return _gestaoContasDbContext.Contas.FirstOrDefault(p => p.Identificador == identificador);
        }
        public decimal VerificaSaldoOrigem(int identificadorOrigem)
        {
            return _gestaoContasDbContext.Depositos
                    .Where(p => p.Identificador == identificadorOrigem)
                    .Sum(p => p.Valor);
        }

        public void AtualizarSaldoConta(int identificador)
        {
            var saldoDepositos = BuscaSaldoDeposito(identificador);
            var saldoTransferencias = BuscaSaldoTransferencia(identificador);

            var saldoAposTransacao = saldoDepositos + saldoTransferencias;

            Conta atualizarSaldo = new Conta(identificador, saldoAposTransacao);
            _gestaoContasDbContext.Contas.Update(atualizarSaldo);
            _gestaoContasDbContext.SaveChanges();
        }

        private decimal BuscaSaldoDeposito(int identificador)
        {
            var valorSaldoDeposito = _gestaoContasDbContext.Depositos
                .Where(p => p.Identificador == identificador)
                .Sum(p => p.Valor);

            return valorSaldoDeposito;
        }
        private decimal BuscaSaldoTransferencia(int identificador)
        {
            var valorTransferenciasOrigem = _gestaoContasDbContext.Transferencias
                .Where(p => p.IdentificadorOrigem == identificador)
                .Sum(p => -p.Valor);

            var valorTransferenciasDestino = _gestaoContasDbContext.Transferencias
                .Where(p => p.IdentificadorDestino == identificador)
                .Sum(p => p.Valor);

            return valorTransferenciasOrigem + valorTransferenciasDestino;
        }
    }
}
