using System;

namespace Candyshop.Models
{
    public class StatisticalData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string State { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
