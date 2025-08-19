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

        public async Task UpdateMovie(Movie movie)
        {
            var existingMovie = _context.Movies.Find(movie.Id);
            if (existingMovie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {movie.Id} not found");
            }
            _context.Entry(existingMovie).CurrentValues.SetValues(movie);
            await _context.SaveChangesAsync();
        }
    }
}
