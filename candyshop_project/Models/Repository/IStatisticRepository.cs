using Candyshop.Models;
using System.Collections.Generic;

namespace candyshop_project.Models.Repository
{
    public interface IStatisticRepository
    {
        List<ChartData> AmountPerDayChartData();
        List<ChartData> RevenuePerDayChartData();

        ChartData StateData();

        List<ChartData> TopLoyalCustomersData();
    }
}