using Candyshop.Models;
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
    }
}
