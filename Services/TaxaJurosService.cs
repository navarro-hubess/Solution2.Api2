using Config;
using DDD.Financial;
using DecimalMath;
using System;
using System.Net.Http;


namespace Services
{
    
    public interface ITaxaJurosService
    {
        decimal CalcularJuros(decimal valorInicial, int tempo);
    }

    public class TaxaJurosService : ITaxaJurosService
    {

        private readonly HttpClient _httpClient;
        private readonly ITaxaJurosApiConfig _taxaJurosApiConfig;

        public TaxaJurosService(HttpClient httpClient, ITaxaJurosApiConfig taxaJurosApiConfig)
        {
            
            _httpClient = httpClient;
            _taxaJurosApiConfig = taxaJurosApiConfig;
        }

        public decimal CalcularJuros(decimal valorInicial, int tempo)
        {
            var juros = _httpClient.GetAsync($"{_taxaJurosApiConfig.BaseUrl}").Result;
            //decimal calc1 = valorInicial * (1 + juros);
            //decimal valorFinal = Math.Truncate(DecimalEx.Pow(calc1, tempo));
            //return valorFinal;
            return 1;
        }
    }


}
