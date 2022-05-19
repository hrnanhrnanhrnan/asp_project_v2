using Candyshop.Models;
using candyshop_project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICandyRepository _candyRepo;
        private readonly ICategoryRepositoty _categoryRepo;
        public AdminController(ICandyRepository candyRepo, ICategoryRepositoty categoryRepo)
        {
            _candyRepo = candyRepo;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(CreateCandyViewModel candyVM)
        {
            if (ModelState.IsValid)
            {
                var candy = _candyRepo.CreateCandy(candyVM);
                return RedirectToAction("Details", "Candy", new { id = candy.CandyId});
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var vm = new CreateCandyViewModel();
            vm.Categories = _categoryRepo.GetAllCategories.ToList();

            return View(vm);
        }

        public IActionResult UpdateProduct()
        {
            return View();
        }

        public IActionResult DeleteProduct()
        {
            return View();
        }
    }
}
