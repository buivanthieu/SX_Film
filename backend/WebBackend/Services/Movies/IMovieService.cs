using WebBackend.Dtos.Movies;

namespace WebBackend.Services.Movies
{
    public interface IMovieService
    {
        Task AddMovie(CreateMovieDto movieDto);
    }
}