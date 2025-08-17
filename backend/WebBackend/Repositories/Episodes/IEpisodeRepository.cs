
using WebBackend.Models;

namespace WebBackend.Repositories.Episodes
{
    public interface IEpisodeRepository
    {
        //Task<ICollection<Episode>> GetAllEpisodes();
        Task<Episode?> GetEpisodeById(int id);
        Task<ICollection<Episode>> GetEpisodesBySeasonId(int seasonId);
        Task AddEpisode(Episode episode);
        Task UpdateEpisode(Episode episode);
        Task DeleteEpisode(int id);
    }
}