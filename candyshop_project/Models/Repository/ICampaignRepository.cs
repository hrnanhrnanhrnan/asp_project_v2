using Candyshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Candyshop.Models
{
    public interface ICampaignRepository
    {
        public IEnumerable<Campaign> Campaigns { get; }
        public IEnumerable<Campaign> UpcomingCampaigns { get; }
        public IEnumerable<Campaign> PreviusCampaigns { get; }
        public IEnumerable<Campaign> CurrentCampaigns { get; }

        IEnumerable<Campaign> GetWithCandy(int id);
        IEnumerable<Campaign> GetWithCandyCategory(int id);
        IEnumerable<Campaign> GetUpcomingCampaigns(DateTime date);
        IEnumerable<Campaign> GetPreviusCampaigns(DateTime date);
        IEnumerable<Campaign> GetActiveCampaigns(DateTime date);
        Campaign GetById(int id);
        void DeleteCampaign(Campaign campaign);
        void CreateCampaign(Campaign campaign);
        void UpdateCampaign(Campaign campaign);
        void CreateDiscount(Discount campaign);
        void UpdateDiscount(Discount campaign);
        void DeleteDiscount(Discount campaign);
        Discount GetDiscountById(int id);
    }
    public class CampaignRepository : ICampaignRepository
    {
        private readonly AppDbContext _appDbContext;

        public CampaignRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Campaign> Campaigns => _appDbContext.Campaign.Include(c => c.Discounts).ThenInclude(c => c.Candy);
        public IEnumerable<Campaign> UpcomingCampaigns => GetUpcomingCampaigns(DateTime.Now);
        public IEnumerable<Campaign> PreviusCampaigns => GetPreviusCampaigns(DateTime.Now);
        public IEnumerable<Campaign> CurrentCampaigns => GetActiveCampaigns(DateTime.Now);

        public IEnumerable<Campaign> GetWithCandy(int id) => Campaigns.Where(c => c.Discounts.Any(d => d.Candy.CandyId == id));
        public IEnumerable<Campaign> GetWithCandyCategory(int id) => Campaigns.Where(c => c.Discounts.Any(d => d.Candy.CategoryId == id));
        public IEnumerable<Campaign> GetUpcomingCampaigns(DateTime date) => Campaigns.Where(c => c.Start > date);
        public IEnumerable<Campaign> GetPreviusCampaigns(DateTime date) => Campaigns.Where(c => c.End < date);
        public IEnumerable<Campaign> GetActiveCampaigns(DateTime date) => Campaigns.Where(c => c.Start < date && c.End > date);

        public Campaign GetById(int id) => _appDbContext.Campaign.Include(c => c.Discounts).ThenInclude(c => c.Candy).FirstOrDefault(c => c.ID == id);

        public void CreateCampaign(Campaign campaign)
        {
            _appDbContext.Campaign.Add(campaign);
            _appDbContext.SaveChanges();
        }

        public void UpdateCampaign(Campaign campaign)
        {
            _appDbContext.Campaign.Update(campaign);
            _appDbContext.SaveChanges();
        }

        public void DeleteCampaign(Campaign campaign)
        {
            _appDbContext.Campaign.Remove(campaign);
            _appDbContext.Discount.RemoveRange(_appDbContext.Discount.Include(d => d.Campaign).Where(d => d.Campaign.ID == campaign.ID));
            _appDbContext.SaveChanges();
        }

        public void CreateDiscount(Discount discount)
        {
            _appDbContext.Discount.Add(discount);
            _appDbContext.SaveChanges();
        }

        public void UpdateDiscount(Discount discount)
        {
            _appDbContext.Discount.Update(discount);
            _appDbContext.SaveChanges();
        }

        public void DeleteDiscount(Discount discount)
        {
            _appDbContext.Discount.Remove(discount);
            _appDbContext.SaveChanges();
        }

        public Discount GetDiscountById(int id) => _appDbContext.Discount.FirstOrDefault(c => c.ID == id);
    }
}
