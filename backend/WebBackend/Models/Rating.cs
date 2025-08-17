namespace WebBackend.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int? FilmId { get; set; }
        public Film? Film { get; set; }
        public int? EpisodeId { get; set; }
        public Episode? Episode { get; set; }
        public int Score { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
