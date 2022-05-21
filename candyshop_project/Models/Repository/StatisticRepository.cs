using Candyshop.Models;
using System.Collections.Generic;
using System.Linq;

namespace candyshop_project.Models.Repository
{
    public class StatisticRepository : IStatisticRepository
    {

        private readonly AppDbContext _appDbContext;

        public StatisticRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<ChartData> AmountPerDayChartData()
        {
            var data = _appDbContext.Orders.GroupBy(x => x.OrderPlaced.Date)
                .Select(group => new ChartData
                {
                    Date = group.Key.Date,
                    Amount = group.Count(),

                }).ToList();

            return data;
        }

        public ChartData StateData()
        {
            var data = _appDbContext.Orders.GroupBy(x => x.State)
                .Select(group => new ChartData
                {
                    State = group.Key,
                    Amount = group.Sum(x => x.OrderTotal),
                }).OrderByDescending(x => x.Amount).First();

            return data;
        }

        public List<ChartData> RevenuePerDayChartData()
        {
            var data = _appDbContext.Orders.GroupBy(x => x.OrderPlaced.Date)
                .Select(group => new ChartData
                {
                    Date = group.Key.Date,
                    Amount = group.Sum(x => x.OrderTotal),

                }).ToList();

            return data;
        }

        public List<ChartData> TopLoyalCustomersData()
        {
            var data = _appDbContext.Orders.GroupBy(x => new
            {
                x.FirstName,
                x.LastName
            }).Select(group => new ChartData
            {
                Name = group.Key.FirstName + " " + group.Key.LastName,
                Amount = group.Sum(x => x.OrderTotal),
            }).OrderByDescending(x => x.Amount).Take(3).ToList();

            return data;

        }



    }
}
