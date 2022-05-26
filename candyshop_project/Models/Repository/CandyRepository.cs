using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candyshop.Models
{
    public class CandyRepository : ICandyRepository
    {
        private readonly AppDbContext _appDbContext;

        public CandyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Candy> GetAllCandy
        {
            get
            {
                return _appDbContext.Candies.Include(c => c.Category).Include(c => c.Discounts).ThenInclude(d => d.Campaign);
            }

        }

        public IEnumerable<Candy> GetCandyOnSale
        {
            get
            {
                var res = _appDbContext.Candies.Include(c => c.Category).Include(c => c.Discounts).ThenInclude(d => d.Campaign).ToArray();
                return res.Where(p => p.IsOnSale);
            }
        }

        public Candy CreateCandy(Candy candy)
        {
            if (candy != null)
            {
                _appDbContext.Candies.Add(candy);
                _appDbContext.SaveChanges();
                return candy;
            }
            return null;
        }

        public Candy GetCandyById(int candyId)
        {
            return _appDbContext.Candies.Include(c => c.Category).FirstOrDefault(c => c.CandyId == candyId);
        }

        public Candy UpdateCandy(Candy candy)
        {
            var candyFromDb = _appDbContext.Candies.Include(c => c.Category).FirstOrDefault(c => c.CandyId == candy.CandyId);
            if (candyFromDb != null)
            {
                candyFromDb.AmountInStock = candy.AmountInStock;
                candyFromDb.Description = candy.Description;
                candyFromDb.Name = candy.Name;
                candyFromDb.Price = candy.Price;
                _appDbContext.SaveChanges();
                return candyFromDb;
            }
            return candy;
        }

        public void DeleteCandy(int id)
        {
            var candy = _appDbContext.Candies.FirstOrDefault(c => c.CandyId == id);
            if (candy != null)
            {
                _appDbContext.Candies.Remove(candy);
                _appDbContext.SaveChanges();
            }
        }

        public IEnumerable<Candy> GetMostPopular(int count)
        {
            var scores = new Dictionary<int, int>();
            foreach (var detail in _appDbContext.OrderDetails)
            {
                if (scores.TryGetValue(detail.CandyId, out int score))
                    scores[detail.CandyId] = score + detail.Amount;
                else
                    scores[detail.CandyId] = detail.Amount;
            }

            return scores.OrderByDescending(kvp => kvp.Value).Take(count).Select(kvp => GetCandyById(kvp.Key));
        }
    }
}
