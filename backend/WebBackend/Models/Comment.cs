namespace WebBackend.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? UserId { get; set; }
        public User? User { get; set; }

        public int? FilmId { get; set; }
        public Film? Film { get; set; }
        public int? EpisodeId { get; set; }
        public Episode? Episode { get; set; }

        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; } = new List<Comment>();

        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
