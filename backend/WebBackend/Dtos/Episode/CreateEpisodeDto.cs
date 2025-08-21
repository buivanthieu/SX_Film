namespace WebBackend.Dtos.Episode
{
    public class CreateEpisodeDto
    {
        public int EpisodeNumber { get; set; }
        public string Title { get; set; } = null!;
        public int Duration { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Quality { get; set; }
        public string VideoUrl { get; set; } = null!;
    }
}
