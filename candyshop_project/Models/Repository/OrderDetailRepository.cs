using Candyshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _context;
        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails.Include(od => od.Candy).Include(od => od.Order);
        }
    }
}
