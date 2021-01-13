using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoJurosController : Controller
    {
        private readonly ITaxaJurosService _taxaJurosService;
        public CalculoJurosController(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        [HttpGet]
        //[Route("calculaJuros/{valorInicial:decimal}/{tempo:int}")]
        [Route("calculaJuros")]
        public async Task<IActionResult> CalcularJurosAsync([FromQuery] decimal valorInicial, [FromQuery] int tempo)
        {
            var montante = await _taxaJurosService.CalcularMontanteAsync(valorInicial, tempo);
            return Ok(montante);
        }

        [HttpGet]
        [Route("showmethecode")]
        public string ShowMeTheCode()
        {
            return "";
        }
    }
}
