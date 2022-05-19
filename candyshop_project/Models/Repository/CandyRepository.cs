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
            return _appDbContext.Candies.FirstOrDefault(c => c.CandyId == candyId);
        }
    }
}
