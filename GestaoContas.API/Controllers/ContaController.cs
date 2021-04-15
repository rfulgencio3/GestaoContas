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
    }
}
