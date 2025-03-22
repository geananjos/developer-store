using Microsoft.EntityFrameworkCore;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.Interfaces;
using SalesSystem.Infrastructure.Persistence;

namespace SalesSystem.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SalesDbContext _context;

        public ProductRepository(SalesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.Category.ToLower() == category.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllCategoriesAsync()
        {
            return await _context.Products
                .Select(p => p.Category)
                .Distinct()
                .ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Product> Query()
        {
            return _context.Products.AsNoTracking();
        }
    }
}
