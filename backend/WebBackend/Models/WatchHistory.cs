namespace WebBackend.Models
{
    public class WatchHistory
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int? FilmId { get; set; }
        public Film? Film { get; set; }

        public int? EpisodeId { get; set; }
        public Episode? Episode { get; set; }

        public DateTime WatchedAt { get; set; } = DateTime.UtcNow;

        public int ProgressSeconds { get; set; }   
        public bool IsFinished { get; set; } = false; 
    }
}
