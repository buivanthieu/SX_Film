using WebBackend.Models;

namespace WebBackend.Repositories.Bookmarks
{
    public interface IBookmarkRepository
    {
        Task<Bookmark?> GetBookmarkById(int id);
        Task<ICollection<Bookmark>> GetBookmarksByUserId(int userId);
        Task AddBookmark(Bookmark bookmark);
        Task DeleteBookmark(int id);
        Task<bool> CheckExistBookmark (int userId, int filmId);

    }
}