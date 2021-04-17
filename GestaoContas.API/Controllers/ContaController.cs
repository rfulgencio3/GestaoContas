using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult ObterTodas()
        {
            return Ok(_contaRepository.ObterTodas());
        }
        
        [HttpPost]
        public IActionResult Adicionar([FromBody] Conta conta)
        {
            _contaRepository.Adicionar(conta);
            return Ok("Conta adicionada com sucesso.");
        }
    }
}
