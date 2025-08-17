using Microsoft.EntityFrameworkCore;
using WebBackend.Datas;
using WebBackend.Models;
using WebBackend.Repositories.BookmarkActors;

namespace WebBackend.Repositories.BookmarkActorActors
{
    public class BookmarkActorRepository : IBookmarkActorRepository
    {
        private readonly ApplicationDbContext _context;
        public BookmarkActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddBookmarkActor(BookmarkActor bookmark)
        {
            _context.BookmarkActors.Add(bookmark);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckExistBookmarkActor(int userId, int actorId)
        {
            return await _context.BookmarkActors
                .AnyAsync(b => b.UserId == userId && b.ActorId == actorId);
        }

        public async Task DeleteBookmarkActor(int id)
        {
            var bookmark = await _context.BookmarkActors.FindAsync(id);
            if (bookmark != null)
            {
                _context.BookmarkActors.Remove(bookmark);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<BookmarkActor?> GetBookmarkActorById(int id)
        {
            return await _context.BookmarkActors
                .Include(b => b.Actor)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<ICollection<BookmarkActor>> GetBookmarkActorsByUserId(int userId)
        {
            return await _context.BookmarkActors
                .Where(b => b.UserId == userId)
                .Include(b => b.Actor)
                .ToListAsync();
        }


    }
}

