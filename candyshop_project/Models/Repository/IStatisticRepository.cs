using Candyshop.Models;
using System.Collections.Generic;

namespace candyshop_project.Models.Repository
{
    public interface IStatisticRepository
    {
        List<StatisticalData> AmountPerDayChartData();
        List<StatisticalData> RevenuePerDayChartData();

        StatisticalData StateData();

        List<StatisticalData> TopLoyalCustomersData();
        List<StatisticalData> InventoryData();
        List<StatisticalData> PopularProducts();


    }
}