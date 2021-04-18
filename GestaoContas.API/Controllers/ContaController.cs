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
    [Route("api/contas")]
    public class ContaController : ControllerBase
    {
        IContaRepository _contaRepository;
        ICorrentistaRepository _correntistaRepository;
        public ContaController(IContaRepository contaRepository, ICorrentistaRepository correntistaRepository)
        {
            _contaRepository = contaRepository;
            _correntistaRepository = correntistaRepository;
        }

        [HttpGet]
        public IActionResult ObterPorIdentificador(Conta conta)
        {
            try
            {
                if (!_correntistaRepository.Existe(conta.Identificador))
                {
                    return StatusCode(404, $"Transação não realizada, favor verificar se existe o identificador {conta.Identificador} cadastrado.");
                }
                return Ok(conta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message.ToString()}");
            }
        }
    }
}