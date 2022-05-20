using Candyshop.Models;
using candyshop_project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Candyshop.Controllers
{
    public class StatisticController:Controller
    {
        private readonly IOrderRepository _orderRepository;

        public StatisticController(IOrderRepository orderRepository)
        {

            _orderRepository = orderRepository;
        }

        public ViewResult Index()
        {
            ViewBag.DataPointsAmountPerDay = JsonConvert.SerializeObject(_orderRepository.AmountPerDayChartData());
            ViewBag.DataPointsRevenue= JsonConvert.SerializeObject(_orderRepository.RevenuePerDayChartData());

            var model = new ChartDataViewModel();

            model.LoyalCustomerData = _orderRepository.TopLoyalCustomersData();
            model.stateData= _orderRepository.StateData();

            return View(model);
        }
    }
}
