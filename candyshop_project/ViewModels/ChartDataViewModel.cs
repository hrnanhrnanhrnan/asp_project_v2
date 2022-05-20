using Candyshop.Models;
using System.Collections.Generic;

namespace candyshop_project.ViewModels
{
    public class ChartDataViewModel
    {
        public List<ChartData> LoyalCustomerData { get; set; }

        public ChartData stateData { get; set; }  
    }
}
