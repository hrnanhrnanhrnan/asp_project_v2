using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candyshop.Models
{
    public class Campaign
    {
        [Key] public int ID { get; set; }
        public string Name { get; set; } = "Candy Campaign!";

        [DataType(DataType.Date)]
        public DateTime Start { get; set; } = DateTime.Now.Date + TimeSpan.FromDays(1);
        public int Days { get; set; } = 7;
        public DateTime End => Start + TimeSpan.FromDays(Days);
        public List<Discount> Discounts { get; set; } = new List<Discount>();
    }
    public class Discount
    {
        [Key] public int ID { get; set; }
        public double Amount { get; set; }
        public bool IsFlatAmount { get; set; }
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public int CandyId { get; set; }
        public Candy Candy { get; set; }

        public decimal PriceWithDiscount => IsFlatAmount ? Candy.Price - (decimal)Amount : Candy.Price * (decimal)(1 - (Amount / 100));
    }
}
