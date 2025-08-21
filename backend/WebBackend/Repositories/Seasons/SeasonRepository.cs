using Microsoft.EntityFrameworkCore;
using WebBackend.Datas;
using WebBackend.Models;

namespace WebBackend.Repositories.Seasons
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly ApplicationDbContext _context;
        public SeasonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddSeason(Season season)
        {
            _context.Seasons.Add(season);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeason(int id)
        {
            var season = await _context.Seasons.FindAsync(id)
                ?? throw new KeyNotFoundException();
            _context.Seasons.Remove(season);
        }

        public async Task<Season?> GetSeasonById(int id)
        {
            var season = await _context.Seasons.FindAsync(id);
            return season;
        }

        public async Task<ICollection<Season>> GetSeasonsByFilmId(int filmId)
        {
            var seasonList = await _context.Seasons
                .Where(e => e.SeriId == filmId)
                .ToListAsync();
            return seasonList;
        }



        public async Task UpdateSeason(int seasonId, Season season)
        {
            var existingSeason = await _context.Seasons.FindAsync(seasonId);
            if (existingSeason == null)
            {
                throw new KeyNotFoundException($"Season with ID {seasonId} not found");
            }
            existingSeason.Title = season.Title;
            existingSeason.SeasonNumber = season.SeasonNumber;
            existingSeason.ReleaseDate = season.ReleaseDate;



            await _context.SaveChangesAsync();

        }
    }
}