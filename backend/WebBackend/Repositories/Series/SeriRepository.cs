using Microsoft.EntityFrameworkCore;
using WebBackend.Datas;
using WebBackend.Models;

namespace WebBackend.Repositories.Series
{
    public class SeriRepository : ISeriRepository
    {
        private readonly ApplicationDbContext _context;
        public SeriRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddSeri(Seri seri)
        {
            _context.Series.Add(seri);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeri(int id)
        {
            var seri = await _context.Series.FindAsync(id)
                ?? throw new KeyNotFoundException();
            _context.Series.Remove(seri);
        }

        public async Task<ICollection<Seri>> GetAllSeries()
        {
            var seris = await _context.Series.ToListAsync();
            return seris;

        }

        public async Task<Seri?> GetSeriById(int id)
        {
            var seri = await _context.Series.FindAsync(id);
            return seri;
        }

        public async Task UpdateSeri(Seri seri)
        {
            var existingSeri = _context.Series.Find(seri.Id);
            if (existingSeri == null)
            {
                throw new KeyNotFoundException($"Seri with ID {seri.Id} not found");
            }
            _context.Entry(existingSeri).CurrentValues.SetValues(seri);
            await _context.SaveChangesAsync();
        }
    }
}
