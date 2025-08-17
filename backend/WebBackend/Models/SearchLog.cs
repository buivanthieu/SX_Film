namespace WebBackend.Models
{
    public class SearchLog
    {
        public int Id { get; set; }

        public int? UserId { get; set; } 
        public User? User { get; set; }

        public string Keyword { get; set; } = null!;

        public DateTime SearchedAt { get; set; } = DateTime.UtcNow;
    }
}
