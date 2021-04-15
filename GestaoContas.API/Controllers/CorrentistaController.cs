using GestaoContas.Domain.Entities;
using GestaoContas.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_correntistaRepository.ObterTodos());
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody]Correntista correntista)
        {
            _correntistaRepository.Adicionar(correntista);
            return Ok("Correntidta adicionado com sucesso.");
        }
    }
}
