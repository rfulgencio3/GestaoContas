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
    [Route("api/depositos")]
    public class DepositoController : ControllerBase
    {
        IDepositoRepository _depositoRepository;
        ICorrentistaRepository _correntistaRepository;
        public DepositoController(IDepositoRepository depositoRepository, ICorrentistaRepository correntistaRepository)
        {
            _depositoRepository = depositoRepository;
            _correntistaRepository = correntistaRepository;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                var correntistas = _depositoRepository.ObterTodosPorIdentificador();
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
        public IActionResult Adicionar([FromBody] Deposito deposito)
        {
            try
            {
                if (!_correntistaRepository.Existe(deposito.Identificador)) 
                {
                    return StatusCode(404, $"Depósito não realizado, favor verificar se existe o identificador {deposito.Identificador} cadastrado.");
                }
                _depositoRepository.Adicionar(deposito);
                _depositoRepository.AtualizaSaldo(deposito);
                return Ok($"Depósito com o valor de R$ {deposito.Valor} para o código identificador {deposito.Identificador} realizado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message.ToString()}");
            }
        }
    }
}