namespace WebBackend.Models
{
    public class Episode
    {
        public int Id { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; } = null!;

        public int EpisodeNumber { get; set; }

        public string Title { get; set; } = null!;

        public int Duration { get; set; }  // phút
        public string Quality { get; set; } = "HD";

        public string VideoUrl { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public string? ThumbnailUrl { get; set; }
    }
}
