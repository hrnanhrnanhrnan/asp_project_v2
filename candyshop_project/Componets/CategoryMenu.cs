using Candyshop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Componets
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepositoty _categoryRepository;

        public CategoryMenu(ICategoryRepositoty categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAllCategories.OrderBy(c => c.CategoryName);

            return View(categories);
        }
    }
}
