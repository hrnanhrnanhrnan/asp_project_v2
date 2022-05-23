using Candyshop.Models;
using candyshop_project.Models.Repository;
using candyshop_project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Candyshop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticController:Controller
    {

        private readonly IStatisticRepository _statisticRepository;

        public StatisticController(IStatisticRepository statisticRepository)
        {

            _statisticRepository = statisticRepository;
        }

        public ViewResult Index()
        {
            ViewBag.DataPointsAmountPerDay = JsonConvert.SerializeObject(_statisticRepository.AmountPerDayChartData());
            ViewBag.DataPointsRevenue= JsonConvert.SerializeObject(_statisticRepository.RevenuePerDayChartData());

            var model = new StatisticalDataViewModel();

            model.LoyalCustomerData = _statisticRepository.TopLoyalCustomersData();
            model.stateData= _statisticRepository.StateData();
            model.InventoryData= _statisticRepository.InventoryData();

            return View(model);
        }
    }
}
