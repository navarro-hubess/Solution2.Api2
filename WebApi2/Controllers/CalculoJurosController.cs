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
        public IActionResult CalcularJuros([FromQuery] decimal valorInicial, [FromQuery] int tempo)
        {
            var juros = _taxaJurosService.CalcularJuros(valorInicial, tempo);
            return Ok();
        }

        [HttpGet]
        [Route("showmethecode")]
        public string ShowMeTheCode()
        {
            return "";
        }
    }
}
