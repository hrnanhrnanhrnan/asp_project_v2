using Candyshop.Models;
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
            ViewBag.DataPointsColumn = JsonConvert.SerializeObject(_orderRepository.AmountPerDayChartData());
            ViewBag.DataPointsState= JsonConvert.SerializeObject(_orderRepository.StateData());
            ViewBag.DataPointsCity= JsonConvert.SerializeObject(_orderRepository.CityData());
            ViewBag.DataPointsRevenue= JsonConvert.SerializeObject(_orderRepository.RevenuePerDayChartData());

            return View();
        }
    }
}
