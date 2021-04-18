using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoContas.API.Controllers
{
    [ApiController]
    [Route("api/transacoes")]
    public class TransacaoController : ControllerBase
    {
        ITransacaoRepository _transacaoRepository;
        ICorrentistaRepository _correntistaRepository;
        public TransacaoController(ITransacaoRepository transacaoRepository, ICorrentistaRepository correntistaRepository)
        {
            _transacaoRepository = transacaoRepository;
            _correntistaRepository = correntistaRepository;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                var correntistas = _transacaoRepository.ObterTodasPorIdentificador();
                if (!correntistas.Any())
                {
                    return NotFound("Nenhuma informação cadastrada.");
                }
                return Ok(correntistas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro na requisição: {ex.Message.ToString()}");
            }
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Transacao transacao)
        {
            try
            {
                if (!_correntistaRepository.Existe(transacao.Identificador)) 
                {
                    return StatusCode(404, $"Transação não realizada, favor verificar se existe o identificador {transacao.Identificador} cadastrado.");
                }
                _transacaoRepository.Adicionar(transacao);
                _transacaoRepository.AtualizaSaldo(transacao);
                return Ok($"Transação com o valor de R$ {transacao.Valor} para o código identificador {transacao.Identificador} realizada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message.ToString()}");
            }
        }
    }
}