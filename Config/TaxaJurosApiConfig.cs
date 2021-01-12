using System;

namespace Config
{

    public interface ITaxaJurosApiConfig
    {
        public string BaseUrl { get; set; }
    }

    public class TaxaJurosApiConfig : ITaxaJurosApiConfig
    {
        public string BaseUrl { get; set; }
    }
}
