using Microsoft.EntityFrameworkCore;
using WebBackend.Datas;
using WebBackend.Models;

namespace WebBackend.Repositories.Bookmarks
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly ApplicationDbContext _context;
        public BookmarkRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddBookmark(Bookmark bookmark)
        {
            _context.Bookmarks.Add(bookmark);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckExistBookmark(int userId, int filmId)
        {
            return await _context.Bookmarks
                .AnyAsync(b => b.UserId == userId && b.FilmId == filmId);
        }

        public async Task DeleteBookmark(int id)
        {
            var bookmark = await _context.Bookmarks.FindAsync(id);
            if (bookmark != null)
            {
                _context.Bookmarks.Remove(bookmark);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Bookmark?> GetBookmarkById(int id)
        {
            return await _context.Bookmarks
                .Include(b => b.Film)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<ICollection<Bookmark>> GetBookmarksByUserId(int userId)
        {
            return await _context.Bookmarks
                .Where(b => b.UserId == userId)
                .Include(b => b.Film) 
                .ToListAsync();
        }

        
    }
}
