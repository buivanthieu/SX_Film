using WebBackend.Models;

namespace WebBackend.Repositories.Movies
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetAllMovies();
        Task<Movie?> GetMovieById(int id);
        Task AddMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
    }
}