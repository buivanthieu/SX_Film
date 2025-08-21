using WebBackend.Models;

namespace WebBackend.Repositories.Seasons
{
    public interface ISeasonRepository
    {
        Task<Season?> GetSeasonById(int id);
        Task<ICollection<Season>> GetSeasonsByFilmId(int filmId);
        Task AddSeason(Season season);
        Task UpdateSeason(int seasonId, Season season);
        Task DeleteSeason(int id);
    }
}