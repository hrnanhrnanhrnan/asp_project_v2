using Candyshop.Models;
using Candyshop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Controllers
{
    public class ShoppingCartController : Controller 
    {
        private readonly ICandyRepository _candyRepositoyr;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ICandyRepository candyRepositoyr, ShoppingCart shoppingCart)
        {
            _candyRepositoyr = candyRepositoyr;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int candyId)
        {
            var selectedCandy = _candyRepositoyr.GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);

            if(selectedCandy != null)
            {
                _shoppingCart.AddToCart(selectedCandy, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCar(int candyId)
        {
            var selectedCandy = _candyRepositoyr.GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);

            if (selectedCandy != null)
            {
                _shoppingCart.RemoveFromCart(selectedCandy);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult clearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
