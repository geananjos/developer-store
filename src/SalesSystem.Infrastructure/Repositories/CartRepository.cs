using Microsoft.EntityFrameworkCore;
using SalesSystem.Domain.Carts;
using SalesSystem.Domain.Carts.Interfaces;
using SalesSystem.Infrastructure.Persistence;

namespace SalesSystem.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly SalesDbContext _context;

        public CartRepository(SalesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _context.Carts.AsNoTracking().ToListAsync();
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            return await _context.Carts
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cart cart)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Cart> Query()
        {
            return _context.Carts.AsNoTracking().Include(c => c.Products);
        }
    }
}
