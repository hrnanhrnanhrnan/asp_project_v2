using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public interface IOrderRepository
    {
        void CreatOrder(Order order);

        List<ChartData> ChartData();
    }
}
