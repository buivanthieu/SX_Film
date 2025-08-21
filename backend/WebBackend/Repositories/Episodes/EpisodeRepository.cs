
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

        public async Task<ICollection<Episode>> GetEpisodesBySeasonId(int episodeId)
        {
            var episodeList = await _context.Episodes
                .Where(e => e.SeasonId == episodeId)
                .ToListAsync();
            return episodeList;
        }

        

        public async Task UpdateEpisode(int episodeId, Episode episode)
        {
            var existingEpisode = await _context.Episodes.FindAsync(episodeId);
            if (existingEpisode == null)
            {
                throw new KeyNotFoundException($"Episode with ID {episodeId} not found");
            }
            existingEpisode.Title = episode.Title;
            existingEpisode.EpisodeNumber = episode.EpisodeNumber;
            existingEpisode.Duration = episode.Duration;
            existingEpisode.ReleaseDate = episode.ReleaseDate;
            existingEpisode.ThumbnailUrl = episode.ThumbnailUrl;
            existingEpisode.Quality = episode.Quality;
            existingEpisode.VideoUrl = episode.VideoUrl;


            await _context.SaveChangesAsync();


        }
    }
}
