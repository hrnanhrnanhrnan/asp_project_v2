using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Candyshop
{
    public class CurrencyRate
    {
        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string, double> Rates { get; set; }
    }
}
