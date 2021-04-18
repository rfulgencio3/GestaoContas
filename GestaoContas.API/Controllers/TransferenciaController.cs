using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestaoContas.API.Controllers
{
    [ApiController]
    [Route("api/transferencias")]
    public class TransferenciaController : ControllerBase
    {
        ITransferenciaRepository _transferenciaRepository;
        ICorrentistaRepository _correntistaRepository;
        IContaRepository _contaRepository;
        public TransferenciaController(ITransferenciaRepository transferenciaRepository, ICorrentistaRepository correntistaRepository, IContaRepository contaRepository)
        {
            _transferenciaRepository = transferenciaRepository;
            _correntistaRepository = correntistaRepository;
            _contaRepository = contaRepository;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Transferencia transferencia)
        {
            if(transferencia.Valor <= 0.00M)
            {
                return StatusCode(404, $"Transferência não realizada, valor da transferência deve ser maior que R$ 0,00.");
            }
            if(transferencia.IdentificadorOrigem == transferencia.IdentificadorDestino)
            {
                return StatusCode(404, $"Transferência não realizada, o identificador origem e destino não pode ser o mesmo {transferencia.IdentificadorOrigem}.");
            }
            if (!_correntistaRepository.Existe(transferencia.IdentificadorOrigem))
            {
                return StatusCode(404, $"Transferência não realizada, favor verificar se existe o identificador origem {transferencia.IdentificadorOrigem} cadastrado.");
            }
            if (!_correntistaRepository.Existe(transferencia.IdentificadorDestino))
            {
                return StatusCode(404, $"Transferência não realizada, favor verificar se existe o identificador destino {transferencia.IdentificadorDestino} cadastrado.");
            }

            try
            {
                var saldoAtual = _contaRepository.VerificaSaldoOrigem(transferencia.IdentificadorOrigem);
                if (saldoAtual <= transferencia.Valor)
                {
                    return StatusCode(404, $"Transferência não realizada, saldo insuficiente para realizar a transação. Saldo conta origem R$ {saldoAtual}.");
                }

                _transferenciaRepository.Adicionar(transferencia);
                
                _contaRepository.AtualizarSaldoContaOrigem(transferencia);
                _contaRepository.AtualizarSaldoContaDestino(transferencia);
                return Ok($"Transferência da conta de origem {transferencia.IdentificadorOrigem} para conta destino {transferencia.IdentificadorDestino} com o valor de R$ {transferencia.Valor}, foi realizada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message.ToString()}");
            }
        }
    }
}
