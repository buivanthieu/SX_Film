namespace WebBackend.Dtos.Films
{
    public class CreateFilmDto
    {
        public string Title { get; set; } = null!;
        public string? OriginalTitle { get; set; }
        public string Description { get; set; } = null!;
        public string? Language { get; set; }
        public int ReleaseYear { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Country { get; set; }
        public string PosterUrl { get; set; } = null!;
        public string? BannerUrl { get; set; }
        public string? TrailerUrl { get; set; }
        
    }
}
