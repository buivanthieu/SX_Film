namespace WebBackend.Dtos.SearchLogs
{
    public class CreateSearchLogDto
    {
        public int? UserId { get; set; } 

        public string Keyword { get; set; } = null!;

        public DateTime SearchedAt { get; set; } = DateTime.UtcNow;
    }
}
