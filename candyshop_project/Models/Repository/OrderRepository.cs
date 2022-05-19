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
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    Price = shoppingCartItem.Candy.Price,
                    CandyId = shoppingCartItem.Candy.CandyId,
                    OrderId = order.OrderId
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }

        public List<ChartData> ChartData()
        {
            var res = _appDbContext.Orders.GroupBy(x => x.OrderPlaced)
                .Select(group => new ChartData
                {
                    Date= group.Key.Date,
                    ProductAmount = group.Count(),

                }).ToList();

            return res;
        }
    }
}
