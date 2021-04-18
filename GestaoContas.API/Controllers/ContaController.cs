using GestaoContas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestaoContas.API.Controllers
{
    [ApiController]
    [Route("api/contas")]
    public class ContaController : ControllerBase
    {
        IContaRepository _contaRepository;
        public ContaController(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        [HttpGet("{identificador}")]
        public IActionResult ObterPorIdentificador(int identificador)
        {
            try
            {
                var conta = _contaRepository.ObterPorIdentificador(identificador);
                if (conta == null)
                {
                    return StatusCode(404, $"Consulta não realizada, não foi localizado valor de saldo para o identificador {identificador}.");
                }
                return Ok(conta.Saldo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message.ToString()}");
            }
        }
    }
}