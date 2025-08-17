using WebBackend.Models;

namespace WebBackend.Repositories.BookmarkActors
{
    public interface IBookmarkActorRepository
    {
        Task<BookmarkActor?> GetBookmarkActorById(int id);
        Task<ICollection<BookmarkActor>> GetBookmarkActorsByUserId(int userId);
        Task AddBookmarkActor(BookmarkActor bookmark);
        Task DeleteBookmarkActor(int id);
        Task<bool> CheckExistBookmarkActor(int userId, int filmId);
    }
}