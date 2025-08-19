using WebBackend.Dtos.Films;

namespace WebBackend.Dtos.Movies
{
    public class CreateMovieDto : CreateFilmDto
    {
        public int Duration { get; set; }
        public string? Quality { get; set; }
        public string VideoUrl { get; set; } = null!;
    }
}
