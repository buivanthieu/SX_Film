using WebBackend.Dtos.Series;

namespace WebBackend.Services.Series
{
    public interface ISeriService
    {

        Task AddSeri(CreateSeriDto seriesDto);
        Task UpdateSeri(int seriId, UpdateSeriDto seriesDto);
        Task DeleteSeri(int id);
        Task<ICollection<GetSeriDto>> GetAllSeries();
        Task<GetSeriDto> GetSeriById(int id);
    }
}