using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GestaoContas.API.Controllers
{
    [ApiController]
    [Route("api/correntistas")]
    public class CorrentistaController : ControllerBase
    {
        ICorrentistaRepository _correntistaRepository;
        public CorrentistaController(ICorrentistaRepository correntistaRepository)
        {
            _correntistaRepository = correntistaRepository;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                var correntistas = _correntistaRepository.ObterTodos();
                if (!correntistas.Any())
                {
                    return NotFound();
                }
                return Ok(correntistas);
            }
            catch(Exception ex)
            {
                return BadRequest($"Ocorreu um erro na requisição: {ex.Message.ToString()}");
            }
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody]Correntista correntista)
        {
            try
            {
                if (_correntistaRepository.Existe(correntista.Identificador))
                {
                    return StatusCode(409, "Já existe um cadastro com esse numero de Identificador.");
                }
                _correntistaRepository.Adicionar(correntista);
                return Ok($"Correntista com código identificador {correntista.Identificador} adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message.ToString()}");
            }

        }

        [HttpPut]
        public IActionResult Atualizar([FromBody]Correntista correntista)
        {
            try
            {
                if (_correntistaRepository.Existe(correntista.Identificador))
                {
                    _correntistaRepository.Atualizar(correntista);
                    return Ok("Registro atualizado.");
                }
                return NotFound("Registo não encontrado.");
                
            }
            
        }

        [HttpPatch]
        public IActionResult AtualizarParcialmente([FromBody]Correntista correntista)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok();
        }
    }
}
