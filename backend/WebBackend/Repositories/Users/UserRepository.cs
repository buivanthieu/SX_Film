using Microsoft.EntityFrameworkCore;
using WebBackend.Datas;
using WebBackend.Models;

namespace WebBackend.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId)
                ?? throw new KeyNotFoundException();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _context.Users.Include(u => u.Comments)
                .Include(u => u.Ratings)
                .Include(u => u.Reports)
                .Include(u => u.Bookmarks)
                .Include(u => u.BookmarkActors)
                .Include(u => u.Notifications)
                .Include(u => u.SearchLogs)
                .Include(u => u.WatchHistories)
                .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task UpdateUser(int userId, User user)
        {
            var existingUser = await _context.Users.FindAsync(userId)
                ?? throw new KeyNotFoundException();

            existingUser.DisplayName = user.DisplayName;
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.PasswordSalt = user.PasswordSalt;
            existingUser.Role = user.Role;
            existingUser.UpdatedAt = DateTime.UtcNow;
            existingUser.IsActive = user.IsActive;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
        }
    }
}
