using WebBackend.Dtos.Movies;

namespace WebBackend.Services.Movies
{
    public interface IMovieService
    {
        Task AddMovie(CreateMovieDto movieDto);
        Task UpdateMovie(UpdateMovieDto movieDto);
        Task DeleteMovie(int id);
        Task<ICollection<GetMovieDto>> GetAllMovies();
        Task<GetMovieDto> GetMovieById(int id);
    }
}