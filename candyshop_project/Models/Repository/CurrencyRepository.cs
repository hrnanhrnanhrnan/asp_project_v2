using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace Candyshop.Models
{
    public interface ICurrencyRepository
    {
        CurrencyRate GetRate(string currency, DateTime date);
        CurrencyRate this[string currency, DateTime date]
        {
            get;
        }
    }

    public class CurrencyRepository : ICurrencyRepository
    {
        static Dictionary<string, Dictionary<DateTime, CurrencyRate>> cachedRates = new Dictionary<string, Dictionary<DateTime, CurrencyRate>>();
        HttpClient client;
        public CurrencyRepository()
        {
            client = new HttpClient();
        }
        ~CurrencyRepository()
        {
            client.Dispose();
        }

        public CurrencyRate this[string currency, DateTime time] => GetRate(currency, time);

        public CurrencyRate GetRate(string currency, DateTime time)
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
