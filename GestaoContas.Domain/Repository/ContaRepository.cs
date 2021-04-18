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
        public void AtualizarSaldos(Transferencia transferencia)
        {
            AtualizarSaldoContaOrigem(transferencia);
            AtualizarSaldoContaDestino(transferencia);
        }

        private void AtualizarSaldoContaOrigem(Transferencia transferencia)
        {
            var saldoOrigem = _gestaoContasDbContext.Depositos
                .Where(p => p.Identificador == transferencia.IdentificadorOrigem)
                .Sum(p => p.Valor);

            var saldoAposTransacao = saldoOrigem - transferencia.Valor;

            Conta atualizaContaSaldoOrigem = new Conta(transferencia.IdentificadorOrigem, saldoAposTransacao);
            _gestaoContasDbContext.Contas.Update(atualizaContaSaldoOrigem);
            _gestaoContasDbContext.SaveChanges();
        }

        private void AtualizarSaldoContaDestino(Transferencia transferencia)
        {
            var saldoDestino = _gestaoContasDbContext.Depositos
                .Where(p => p.Identificador == transferencia.IdentificadorOrigem)
                .Sum(p => p.Valor);

            var saldoAposTransacao = saldoDestino + transferencia.Valor;

            Conta atualizaContaSaldoDestino = new Conta(transferencia.IdentificadorOrigem, saldoAposTransacao);
            _gestaoContasDbContext.Contas.Update(atualizaContaSaldoDestino);
            _gestaoContasDbContext.SaveChanges();
        }
    }
}
