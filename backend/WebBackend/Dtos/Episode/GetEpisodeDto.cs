namespace WebBackend.Dtos.Episode
{
    public class GetEpisodeDto
    {
        public int Id { get; set; }
        public int EpisodeNumber { get; set; }
        public string Title { get; set; } = null!;
        public int Duration { get; set; }  // phút
        public DateTime? ReleaseDate { get; set; }
        public string? ThumbnailUrl { get; set; }
    }
}
