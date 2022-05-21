﻿using Candyshop.Models;
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

        public List<StatisticalData> AmountPerDayChartData()
        {
            var data = _appDbContext.Orders.GroupBy(x => x.OrderPlaced.Date)
                .Select(group => new StatisticalData
                {
                    Date = group.Key.Date,
                    Amount = group.Count(),

                }).ToList();

            return data;
        }

        public StatisticalData StateData()
        {
            var data = _appDbContext.Orders.GroupBy(x => x.State)
                .Select(group => new StatisticalData
                {
                    State = group.Key,
                    Amount = group.Sum(x => x.OrderTotal),
                }).OrderByDescending(x => x.Amount).First();

            return data;
        }

        public List<StatisticalData> RevenuePerDayChartData()
        {
            var data = _appDbContext.Orders.GroupBy(x => x.OrderPlaced.Date)
                .Select(group => new StatisticalData
                {
                    Date = group.Key.Date,
                    Amount = group.Sum(x => x.OrderTotal),

                }).ToList();

            return data;
        }

        public List<StatisticalData> TopLoyalCustomersData()
        {
            var data = _appDbContext.Orders.GroupBy(x => new
            {
                x.FirstName,
                x.LastName
            }).Select(group => new StatisticalData
            {
                Name = group.Key.FirstName + " " + group.Key.LastName,
                Amount = group.Sum(x => x.OrderTotal),
            }).OrderByDescending(x => x.Amount).Take(3).ToList();

            return data;

        }

        public List<StatisticalData> InventoryData()
        {
            var data = _appDbContext.Candies.Select(x => new StatisticalData
            {
                Name = x.Name,
                Amount = x.AmountInStock,
                Price = x.Price,
            }).OrderByDescending(x=>x.Amount).ToList();
            

            return data;
        }

    }
}
