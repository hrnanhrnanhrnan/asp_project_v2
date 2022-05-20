using Candyshop.Models;
using System.Collections.Generic;

namespace Candyshop.Models.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();
    }
}