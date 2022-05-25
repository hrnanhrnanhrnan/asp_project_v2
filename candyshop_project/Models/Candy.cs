using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public class Candy
    {
        [Key]
        public int CandyId { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Minimum 1 letter and Maximum 25 letters")]
        public string Name { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Minimum 1 letter and Maximum 50 letters")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsOnSale => Discounts.Any(d => d.Campaign.End > DateTime.Now && d.Campaign.Start < DateTime.Now);
        public int AmountInStock { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Discount> Discounts { get; set; } = new List<Discount>();

        public Discount FindBestDiscount(DateTime date)
        {
            Discount best = null;
            foreach (var discount in Discounts)
            {
                if (discount.Campaign.End > date && discount.Campaign.Start < date)
                {
                    if (best is null || best.PriceWithDiscount() > discount.PriceWithDiscount())
                        best = discount;
                }
            }
            return best;
        }

        public decimal GetPriceWithBestDiscount(DateTime date) => FindBestDiscount(date)?.PriceWithDiscount() ?? Price;

        public bool IsInStock() => AmountInStock > 0;
    }
}
