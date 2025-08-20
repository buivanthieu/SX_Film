
using WebBackend.Models;

namespace WebBackend.Repositories.Series
{
    public interface ISeriRepository
    {
        Task<ICollection<Seri>> GetAllSeries();
        Task<Seri?> GetSeriById(int id);
        Task AddSeri(Seri series);
        Task UpdateSeri(Seri series);
        Task DeleteSeri(int id);
    }
}