using Config;
using DDD.Financial;
using DecimalMath;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{

    public interface ITaxaJurosService
    {
        Task<decimal> CalcularMontanteAsync(decimal valorInicial, int tempo);
        Task BuscarTaxa();
    }

    public class TaxaJurosService : ITaxaJurosService
    {

        private readonly HttpClient _httpClient;
        private readonly ITaxaJurosApiConfig _taxaJurosApiConfig;
        private decimal juros;

        public TaxaJurosService(HttpClient httpClient, ITaxaJurosApiConfig taxaJurosApiConfig)
        {

            _httpClient = httpClient;
            _taxaJurosApiConfig = taxaJurosApiConfig;
        }

        public async Task BuscarTaxa()
        {
            using (var response = await _httpClient.GetAsync($"{_taxaJurosApiConfig.BaseUrl}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                juros = JsonConvert.DeserializeObject<TaxaJuros>(apiResponse).TaxaDeJuros;
            }
            
        }

        public async Task<decimal> CalcularMontanteAsync(decimal valorInicial, int tempo)
        {
            await BuscarTaxa();
            decimal calc1 = DecimalEx.Pow((1 + juros), tempo) * valorInicial;
            decimal valorFinal = Truncar(calc1);
            return valorFinal;

        }

        private decimal Truncar(decimal valor)
        {
            valor *= 100;
            valor = Math.Truncate(valor);
            valor /= 100;

            return valor;
        }
    }


}
