using Microsoft.EntityFrameworkCore;
using WebBackend.Datas;
using WebBackend.Models;

namespace WebBackend.Repositories.Films
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;

        public FilmRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private IQueryable<Film> IncludeAllNavigation()
        {
            return _context.Films
                .Include(f => f.Genres)
                .Include(f => f.Tags)
                .Include(f => f.FilmActors)
                .Include(f => f.ProductionCompanies)
                .Include(f => f.Bookmarks)
                .Include(f => f.Comments)
                .Include(f => f.Ratings);
        }

        public async Task<ICollection<Film>> GetAllFilms()
        {
            return await IncludeAllNavigation().ToListAsync();
        }

        public async Task<Film?> GetFilmById(int id)
        {
            return await IncludeAllNavigation().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddFilm(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFilm(Film film)
        {
            var existing = await _context.Films.FindAsync(film.Id);
            if (existing == null) throw new KeyNotFoundException("Film not found");

            _context.Entry(existing).CurrentValues.SetValues(film);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film != null)
            {
                _context.Films.Remove(film);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Film>> GetFilmsByActorId(int actorId)
        {
            return await IncludeAllNavigation()
                .Where(f => f.FilmActors.Any(fa => fa.ActorId == actorId))
                .ToListAsync();
        }

        public async Task<ICollection<Film>> GetFilmsByGenreId(int genreId)
        {
            return await IncludeAllNavigation()
                .Where(f => f.Genres.Any(g => g.Id == genreId))
                .ToListAsync();
        }

        public async Task<ICollection<Film>> GetFilmsByTagId(int tagId)
        {
            return await IncludeAllNavigation()
                .Where(f => f.Tags.Any(t => t.Id == tagId))
                .ToListAsync();
        }

        public async Task<ICollection<Film>> GetFilmsByProductionComanyId(int productionComanyId)
        {
            return await IncludeAllNavigation()
                .Where(f => f.ProductionCompanies.Any(pc => pc.Id == productionComanyId))
                .ToListAsync();
        }

        public async Task<ICollection<Film>> SearchFilm(string searchTerm)
        {
            return await IncludeAllNavigation()
                .Where(f => f.Title.Contains(searchTerm)
                         || (f.OriginalTitle != null && f.OriginalTitle.Contains(searchTerm)))
                .ToListAsync();
        }

        public async Task<ICollection<Film>> GetFilmsBookmarkByUserId(int userId)
        {
            return await IncludeAllNavigation()
                .Where(f => f.Bookmarks.Any(b => b.UserId == userId))
                .ToListAsync();
        }

    
        public async Task<ICollection<Film>> GetTopViewed(int topCount)
        {
            return await IncludeAllNavigation()
                .OrderByDescending(f => f.ViewCount)
                .Take(topCount)
                .ToListAsync();
        }

        public async Task<ICollection<Film>> GetTopRated(int topCount)
        {
            return await IncludeAllNavigation()
                .OrderByDescending(f => f.AverageRating)
                .Take(topCount)
                .ToListAsync();
        }

        public async Task<ICollection<Film>> GetFilmsByReleaseYear(int year)
        {
            return await IncludeAllNavigation()
                .Where(f => f.ReleaseYear == year)
                .ToListAsync();
        }

        public async Task<ICollection<Film>> GetFilmsByLanguage(string language)
        {
            return await IncludeAllNavigation()
                .Where(f => f.Language == language)
                .ToListAsync();
        }

        public async Task<ICollection<Film>> GetLatestFilms(int count)
        {
            return await IncludeAllNavigation()
                .OrderByDescending(f => f.ReleaseDate)
                .Take(count)
                .ToListAsync();
        }
    }
}
