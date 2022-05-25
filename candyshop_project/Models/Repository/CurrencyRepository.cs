using candyshop_project.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public interface ICurrencyRepository
    {
        CurrencyRate GetRate(string currency, DateTime date);
        Task<Symbol> GetSymbols();
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
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, $"https://www.currency-api.com/rates?base={currency}&date={date.ToString("yyyy-MM-dd")}");

            var task = client.SendAsync(httpRequest);
            Task.WaitAll(task);
            return rates[date] = JsonConvert.DeserializeObject<CurrencyRate>(task.Result.Content.ReadAsStringAsync().Result);
        }

        public async Task<Symbol> GetSymbols()
        {
            try
            {
                HttpResponseMessage httpRequest = await client.GetAsync("https://www.currency-api.com/symbols");

                if (httpRequest.IsSuccessStatusCode)
                {
                    string currency = await httpRequest.Content.ReadAsStringAsync();
                    Symbol root = JsonConvert.DeserializeObject<Symbol>(currency);
                    return root;
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
