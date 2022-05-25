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

        public HomeController(ICandyRepository candyRepository, ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
            _candyRepository = candyRepository;
        }
        public IActionResult Index()
        {
            _currencyRepository.GetSymbols();
            var homeViewModel = new HomeViewModel
            {
                CandyOnSale = _candyRepository.GetCandyOnSale
            };

            return View(homeViewModel);
        }
    }
}
