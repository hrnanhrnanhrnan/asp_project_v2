using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candyshop.Models;
using Candyshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Candyshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IOrderRepository _orderRepository;

        public HomeController(ICandyRepository candyRepository, ICurrencyRepository currencyRepository, IOrderRepository orderRepository)
        {
            _currencyRepository = currencyRepository;
            _orderRepository = orderRepository;
            _candyRepository = candyRepository;
        }
        public IActionResult Index()
        {
            try
            {

                _currencyRepository.GetSymbols();
                var homeViewModel = new HomeViewModel
                {
                    CandyOnSale = _candyRepository.GetCandyOnSale,
                    MostPopular = _candyRepository.GetMostPopular(6),
                };

                return View(homeViewModel);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
