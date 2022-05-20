﻿using System;
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
                    Price = bestDiscount?.PriceWithDiscount ?? shoppingCartItem.Candy.Price,
                    CandyId = shoppingCartItem.Candy.CandyId,
                    OrderId = order.OrderId
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }

        public List<ChartData> AmountPerDayChartData()
        {
            var data = _appDbContext.Orders.GroupBy(x => x.OrderPlaced.Date)
                .Select(group => new ChartData
                {
                    Date= group.Key.Date,
                    Amount = group.Count(),

                }).ToList();

            return data;
        }

        public ChartData StateData()
        {
            var data = _appDbContext.Orders.GroupBy(x => x.State)
                .Select(group => new ChartData
                {
                    State = group.Key,
                    Amount = group.Sum(x=>x.OrderTotal),
                }).OrderByDescending(x=>x.Amount).First();

            return data;
        }

        public ChartData CityData()
        {
            var data = _appDbContext.Orders.GroupBy(x => x.City)
                .Select(group => new ChartData
                {
                    City = group.Key,
                    Amount = group.Sum(x=>x.OrderTotal),
                }).OrderByDescending(x => x.Amount).First();

            return data;
        }

        public List<ChartData> RevenuePerDayChartData()
        {
            var data = _appDbContext.Orders.GroupBy(x => x.OrderPlaced.Date)
                .Select(group => new ChartData
                {
                    Date = group.Key.Date,
                    Amount = group.Sum(x=>x.OrderTotal),

                }).ToList();

            return data;
        }
    }
}
