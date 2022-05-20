using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Candyshop.Models
{
    public interface IDiscountRepository
    {
        void CreateDiscount(Discount campaign);
        void UpdateDiscount(Discount campaign);
        void DeleteDiscount(Discount campaign);
        Discount GetById(int id);
    }
    public class DiscountRepository : IDiscountRepository
    {
        private readonly AppDbContext _appDbContext;

        public DiscountRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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

        public Discount GetById(int id) => _appDbContext.Discount.Include(d => d.Candy).FirstOrDefault(c => c.ID == id);
    }
}
