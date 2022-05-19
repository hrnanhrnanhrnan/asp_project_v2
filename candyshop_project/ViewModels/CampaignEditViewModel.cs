using Candyshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.ViewModels
{
    public class CampaignEditViewModel
    {
        public Campaign Campaign { get; set; }
        public IEnumerable<Candy> Candies { get; set; }
    }
}
