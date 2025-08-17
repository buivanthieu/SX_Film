namespace WebBackend.Models
{
    public class Report
    {
        public int Id { get; set; }

        public int ReporterId { get; set; }
        public User Reporter { get; set; } = null!;

        public int? FilmId { get; set; }
        public Film? Film { get; set; }

        public int? CommentId { get; set; }
        public Comment? Comment { get; set; }

        public string Reason { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool? IsResolved { get; set; } = false;
    }
}
