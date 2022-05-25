using Candyshop.Models;
using System.Collections.Generic;

namespace candyshop_project.ViewModels
{
    public class StatisticalDataViewModel
    {
        public List<StatisticalData> LoyalCustomerData { get; set; }

        public StatisticalData stateData { get; set; }  

        public List<StatisticalData> InventoryData { get; set; }
        public List<StatisticalData> PopularProducts { get; set; }
    }
}
