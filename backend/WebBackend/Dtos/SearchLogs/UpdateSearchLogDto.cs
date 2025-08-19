using WebBackend.Models;

namespace WebBackend.Dtos.SearchLogs
{
    public class UpdateSearchLogDto
    {
        public int? UserId { get; set; }

        public string Keyword { get; set; } = null!;

        public DateTime SearchedAt { get; set; } = DateTime.UtcNow;
    }
}
