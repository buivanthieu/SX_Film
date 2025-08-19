namespace WebBackend.Dtos.Films
{
    public class GetFilmDto
    {
        public int Id { get; set; }
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
        public string? Discriminator { get; set; }
        public int ViewCount { get; set; }
        public double AverageRating { get; set; }
        public int RatingCount { get; set; }
    }
}
