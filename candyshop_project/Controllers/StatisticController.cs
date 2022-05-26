using Candyshop.Models;
using candyshop_project.Models.Repository;
using candyshop_project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticController:Controller
    {

        private readonly IStatisticRepository _statisticRepository;
        private readonly ICurrencyRepository _currencyRepository;

        public StatisticController(IStatisticRepository statisticRepository, ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
            _statisticRepository = statisticRepository;
        }

        public async Task<ViewResult> Index()
        {
            ViewBag.DataPointsAmountPerDay = JsonConvert.SerializeObject(_statisticRepository.AmountPerDayChartData());
            ViewBag.DataPointsRevenue= JsonConvert.SerializeObject(_statisticRepository.RevenuePerDayChartData());

            var model = new StatisticalDataViewModel();
            var symbols = await _currencyRepository.GetSymbols();
            var existingRates = _currencyRepository.GetRate("SEK", DateTime.Now).Rates;

            model.Symbols = symbols.Symbols.Where(s => existingRates.ContainsKey(s)).ToList();
            model.LoyalCustomerData = _statisticRepository.TopLoyalCustomersData();
            model.stateData = _statisticRepository.StateData();
            model.InventoryData = _statisticRepository.InventoryData();
            model.PopularProducts = _statisticRepository.PopularProducts();

            return View(model);
        }

        /*
        public IActionResult PopularProductFilter(int filterValue)
        {

        }*/
    }
}
