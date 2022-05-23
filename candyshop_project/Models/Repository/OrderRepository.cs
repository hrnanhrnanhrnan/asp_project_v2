using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext , ShoppingCart shoppingCart)
        {
           _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreatOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            foreach(var shoppingCartItem in shoppingCartItems)
            {
                var bestDiscount = shoppingCartItem.Candy.FindBestDiscount(order.OrderPlaced);
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    Price = bestDiscount?.PriceWithDiscount() ?? shoppingCartItem.Candy.Price,
                    CandyId = shoppingCartItem.Candy.CandyId,
                    OrderId = order.OrderId
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }


        public Order GetOrderById(int id)
        {
            var order = _appDbContext.Orders.FirstOrDefault(o => o.OrderId == id);
            if(order != null)
            {
                return order;
            }
            return null;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _appDbContext.Orders;
        }
    }
}
