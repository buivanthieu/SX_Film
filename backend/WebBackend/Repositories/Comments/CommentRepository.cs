using Microsoft.EntityFrameworkCore;
using System.Threading;
using WebBackend.Datas;
using WebBackend.Models;

namespace WebBackend.Repositories.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id)
              ?? throw new KeyNotFoundException("key is null");

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

        }

        public async Task<ICollection<Comment>> GetAllComments()
        {
            var comments = await _context.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            var comment = await _context.Comments.FindAsync(id)
                          ?? throw new KeyNotFoundException("key is null");

            return comment;
        }

        public async Task UpdateComment(Comment comment)
        {
            var existingComment = await _context.Comments.FindAsync(comment.Id)
                          ?? throw new KeyNotFoundException("key is null");

            _context.Entry(existingComment).CurrentValues.SetValues(comment);
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Comment>> GetCommentInFilm(int filmId)
        {
            return await _context.Comments
                .Where(c => c.FilmId == filmId)
                .Include(c => c.User)
                .ToListAsync();
        }
        public async Task<ICollection<Comment>> GetCommentInEpisode(int episodeId)
        {
            return await _context.Comments
                .Where(c => c.EpisodeId == episodeId)
                .Include(c => c.User)
                .ToListAsync();
        }
    }
}
