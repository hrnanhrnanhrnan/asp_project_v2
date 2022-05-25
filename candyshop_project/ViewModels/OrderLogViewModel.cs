using Candyshop;
using Candyshop.Models;
using candyshop_project.Models;
using candyshop_project.Models.DistanceApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace candyshop_project.ViewModels
{
    public class OrderLogViewModel
    {
        public Order Order{ get; set; }
        public string Distance { get; set; }
        public string Duration { get; set; }
        public List<Candy> Candies { get; set; }
        public List<string> Symbols { get; set; }
        public CurrencyRepository CurrencyRate { get; set; } = new CurrencyRepository();
    }
}
