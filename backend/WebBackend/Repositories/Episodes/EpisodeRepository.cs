
using Microsoft.EntityFrameworkCore;
using WebBackend.Datas;
using WebBackend.Models;

namespace WebBackend.Repositories.Episodes
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly ApplicationDbContext _context;
        public EpisodeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddEpisode(Episode episode)
        {
            _context.Episodes.Add(episode);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEpisode(int id)
        {
            var episode = await _context.Episodes.FindAsync(id)
                ?? throw new KeyNotFoundException();
            _context.Episodes.Remove(episode);
        }

        public async Task<Episode?> GetEpisodeById(int id)
        {
            var episode = await _context.Episodes.FindAsync(id);
            return episode;
        }

        public async Task<ICollection<Episode>> GetEpisodesBySeasonId(int seasonId)
        {
            var episodeList = await _context.Episodes
                .Where(e => e.SeasonId == seasonId)
                .ToListAsync();
            return episodeList;
        }

        

        public async Task UpdateEpisode(Episode episode)
        {
            _context.Episodes.Update(episode);
            await _context.SaveChangesAsync();
        }
    }
}
