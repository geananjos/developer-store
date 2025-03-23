using Microsoft.EntityFrameworkCore;
using SalesSystem.Domain.Users;
using SalesSystem.Domain.Users.Interfaces;
using SalesSystem.Infrastructure.Persistence;

namespace SalesSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SalesDbContext _context;

        public UserRepository(SalesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public IQueryable<User> Query()
        {
            return _context.Users.AsNoTracking();
        }
    }
}
