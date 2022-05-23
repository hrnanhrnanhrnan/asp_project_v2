using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Candyshop
{
    public interface ICurrencyManager
    {
        CurrencyRate this[string currency, DateTime date]
        {
            get;
        }
    }

    public class CurrencyManager : ICurrencyManager
    {
        static Dictionary<string, Dictionary<DateTime, CurrencyRate>> cachedRates = new Dictionary<string, Dictionary<DateTime, CurrencyRate>>();
        HttpClient client;
        public CurrencyManager()
        {
            client = new HttpClient();
        }
        ~CurrencyManager()
        {
            client.Dispose();
        }

        public CurrencyRate this[string currency, DateTime time]
        {
            get
            {
                DateTime date = time.Date;
                if (cachedRates.TryGetValue(currency, out Dictionary<DateTime, CurrencyRate> rates))
                {
                    if (rates.TryGetValue(date, out var res))
                        return res;
                }
                else
                {
                    cachedRates[currency] = rates = new Dictionary<DateTime, CurrencyRate>();
                }
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, "https://www.currency-api.com/rates");

                httpRequest.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "base", currency },
                    { "date", date.ToString("yyyy-MM-dd") },
                });

                var result = client.SendAsync(httpRequest).Result;
                return rates[date] = JsonSerializer.Deserialize<CurrencyRate>(result.Content.ReadAsStringAsync().Result);
            }
        }

    }

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
