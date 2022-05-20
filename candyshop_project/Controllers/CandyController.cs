using Candyshop.Models;
using Candyshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepositoty _categoryRepository;
        private readonly IDiscountRepository _discountRepository;

        public CandyController(ICandyRepository candyRepository, ICategoryRepositoty categoryRepository, IDiscountRepository discountRepository)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
            _discountRepository = discountRepository;
        }

        public ViewResult List(string category)
        {
             
            IEnumerable<Candy> candies;
            string currentCategory;
            
            if (string.IsNullOrEmpty(category))
            {
                candies = _candyRepository.GetAllCandy.OrderBy(c => c.CandyId);
                currentCategory ="All Candy";
            }
            else
            {
                candies = _candyRepository.GetAllCandy.Where(c => c.Category.CategoryName == category);

                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new CandyListViewModel 
            {
                Candies = candies, 
                CurrentCategory = currentCategory });
        }

        public IActionResult Details(int id, int discountId)
        {
            var candy = _candyRepository.GetCandyById(id);
            var discount = _discountRepository.GetById(id);
            if (candy == null)
            {
                return NotFound();
            }


            return View(new CandyCardViewModel()
            {
                Candy = candy,
                BestDiscount = discount,
            });

            
        }
    }
}
