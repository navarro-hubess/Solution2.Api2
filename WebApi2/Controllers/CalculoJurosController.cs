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

        /// <summary>
        /// Método para calcular o Montante de um cálculo de Juros Compostos
        /// </summary>
        /// <param name="valorInicial">100</param>
        /// <param name="tempo">5</param>
        /// <returns>Montante truncado em 2 casas decimais</returns>
        [HttpGet]
        [Route("calculaJuros")]
        public async Task<IActionResult> CalcularJurosAsync([FromQuery] decimal valorInicial, [FromQuery] int tempo)
        {
            var montante = await _taxaJurosService.CalcularMontanteAsync(valorInicial, tempo);
            return Ok(montante);
        }

        /// <summary>
        /// Mostra o caminho para os repositórios do GitHub
        /// </summary>
        /// <returns>URL para repositórios</returns>
        [HttpGet]
        [Route("showmethecode")]
        public string ShowMeTheCode()
        {
            return "https://github.com/navarro-hubess/Solution1.Api1";
        }
    }
}
