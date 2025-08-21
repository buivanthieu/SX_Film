using Microsoft.EntityFrameworkCore;
using WebBackend.Datas;
using WebBackend.Models;

namespace WebBackend.Repositories.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id)
                ?? throw new KeyNotFoundException();
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Movie>> GetAllMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies;

        }

        public async Task<Movie?> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return movie;
        }

        public async Task UpdateMovie(int movieId, Movie movie)
        {
            var existingMovie = await _context.Movies.FindAsync(movieId);
            if (existingMovie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {movieId} not found");
            }
            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.ReleaseYear = movie.ReleaseYear;
            existingMovie.Language = movie.Language;
            existingMovie.OriginalTitle = movie.OriginalTitle;
            existingMovie.PosterUrl = movie.PosterUrl;
            existingMovie.BannerUrl = movie.BannerUrl;
            existingMovie.TrailerUrl = movie.TrailerUrl;
            existingMovie.Country = movie.Country;

            existingMovie.VideoUrl = movie.VideoUrl;
            existingMovie.Duration = movie.Duration;
            existingMovie.Quality = movie.Quality;
            await _context.SaveChangesAsync();
        }
    }
}
