using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public class Candy
    {
        public int CandyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsOnSale => Discounts.Any(d => d.Campaign.End > DateTime.Now && d.Campaign.Start < DateTime.Now);
        public int AmountInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Discount> Discounts { get; set; }

        public Discount FindBestDiscount(DateTime date)
        {
            Discount best = null;
            foreach (var discount in Discounts)
            {
                if (discount.Campaign.End > date && discount.Campaign.Start < date)
                {
                    if (best is null || best.PriceWithDiscount > discount.PriceWithDiscount)
                        best = discount;
                }
            }
            return best;
        }

        public bool IsInStock() => AmountInStock > 0;
    }
}
