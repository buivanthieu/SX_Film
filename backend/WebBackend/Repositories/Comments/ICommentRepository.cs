using WebBackend.Models;

namespace WebBackend.Repositories.Comments
{
    public interface ICommentRepository
    {
        Task<ICollection<Comment>> GetAllComments();
        Task<Comment> GetCommentById(int id);
        Task<ICollection<Comment>> GetCommentInFilm(int filmId);
        Task<ICollection<Comment>> GetCommentInEpisode(int episodeId);

        Task AddComment(Comment comment);
        Task DeleteComment(int id);
        Task UpdateComment(Comment comment);
    }
}