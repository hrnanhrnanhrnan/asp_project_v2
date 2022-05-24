using Candyshop.Models;
using Candyshop.Models.Repository;
using candyshop_project.Models;
using candyshop_project.Models.DistanceApiModels;
using candyshop_project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Candyshop.Controllers
{
    
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private static readonly string warehouseOrigin = "Barton County, Kansas, USA";

        static HttpClient client;
        private readonly ICandyRepository _candyRepo;
        private readonly ICategoryRepositoty _categoryRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderDetailRepository _orderDetailRepo;
        public AdminController(ICandyRepository candyRepo, ICategoryRepositoty categoryRepo, IOrderRepository orderRepo, IOrderDetailRepository orderDetailRepo)
        {
            _candyRepo = candyRepo;
            _categoryRepo = categoryRepo;
            _orderRepo = orderRepo;
            _orderDetailRepo = orderDetailRepo;
            client = new HttpClient();
        }
        ~AdminController()
        {
            client.Dispose();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderLogs()
        {
            var orders = _orderRepo.GetAllOrders();
            return View(orders);
        }


        public async Task<IActionResult> OrderLogDetails(int id)
        {
            var order = _orderRepo.GetOrderById(id);
            if(order != null)
            {
                // create new orderlogvm and set order prop from order found by id from orderlogs view,
                // set candies prop from orderdetails table and set distance/duration props by fetching from api by sending in address from order city

                var orderLogViewModel = new OrderLogViewModel
                {
                    Order = order,
                    Candies = _orderDetailRepo.GetAllOrderDetails().Where(od => od.OrderId == order.OrderId).Select(c => c.Candy).ToList()
                };

                HttpResponseMessage response = await client
                    .GetAsync($"https://api.distancematrix.ai/maps/api/distancematrix/json?origins={warehouseOrigin}&destinations={order.City}&key=hmtTj0EEOYZoAZwm2rw8VN7lcoVIQ");

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        Root obj = JsonConvert.DeserializeObject<Root>(data);
                        orderLogViewModel.Duration = obj.Rows[0].Elements[0].Duration.Text;
                        orderLogViewModel.Distance = obj.Rows[0].Elements[0].Distance.Text;
                    }
                    catch (Exception)
                    {
                        orderLogViewModel.Distance = "Not found";
                        orderLogViewModel.Duration = "Not found";
                    }
                }

                return View(orderLogViewModel);
            }

            Response.StatusCode = 404;
            return View("_ItemNotFound", id);
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

            return View(candyVM);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var vm = new CreateCandyViewModel();
            vm.Categories = _categoryRepo.GetAllCategories.ToList();

            return View(vm);
        }

        public IActionResult ListOfCandies()
        {
            return View(_candyRepo.GetAllCandy);
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var candy = _candyRepo.GetCandyById(id);
            if (candy != null)
            {
                return View(candy);
            }

            //return not found error view
            Response.StatusCode = 404;
            return View("_ItemNotFound", id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(Candy model)
        {
            if (ModelState.IsValid)
            {
                _candyRepo.UpdateCandy(model);
                return RedirectToAction("ListOfCandies");
            }

            return View(model);
        }

        public IActionResult DeleteProduct(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var product = _candyRepo.GetCandyById(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(Candy candyToDelete)
        {
            var candy = _candyRepo.GetCandyById(candyToDelete.CandyId);
            if (candy == null)
            {
                return NotFound();
            }
            _candyRepo.DeleteCandy(candy.CandyId);
            return RedirectToAction("ListOfCandies");
        }
    }
}
