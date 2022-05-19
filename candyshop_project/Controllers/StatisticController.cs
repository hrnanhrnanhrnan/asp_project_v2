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
            ViewBag.DataPoints = JsonConvert.SerializeObject(_orderRepository.ChartData());

            return View();
        }
    }
}
