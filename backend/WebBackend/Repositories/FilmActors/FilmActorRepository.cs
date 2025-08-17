using Microsoft.EntityFrameworkCore;
using WebBackend.Datas;
using WebBackend.Models;

public class FilmActorRepository
{
    private readonly ApplicationDbContext _context;

    public FilmActorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Lấy tất cả FilmActor
    public async Task<ICollection<FilmActor>> GetAllFilmActors()
    {
        return await _context.FilmActors.ToListAsync();
    }

    // Lấy FilmActor theo Id
    public async Task<FilmActor> GetFilmActorById(int id)
    {
        var filmActor = await _context.FilmActors.FindAsync(id);
        if (filmActor == null)
            throw new Exception("FilmActor not found");
        return filmActor;
    }

    // Thêm mới FilmActor
    public async Task AddFilmActor(FilmActor filmActor)
    {
        _context.FilmActors.Add(filmActor);
        await _context.SaveChangesAsync();
    }

    // Cập nhật FilmActor
    public async Task UpdateFilmActor(FilmActor filmActor)
    {
        _context.FilmActors.Update(filmActor);
        await _context.SaveChangesAsync();
    }

    // Xóa FilmActor
    public async Task DeleteFilmActor(int id)
    {
        var filmActor = await _context.FilmActors.FindAsync(id);
        if (filmActor != null)
        {
            _context.FilmActors.Remove(filmActor);
            await _context.SaveChangesAsync();
        }
    }
}
