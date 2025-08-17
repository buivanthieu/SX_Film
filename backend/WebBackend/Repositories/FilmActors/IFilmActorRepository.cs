using WebBackend.Models;

namespace WebBackend.Repositories.FilmActors
{
    public interface IFilmActorRepository
    {
        Task<ICollection<FilmActor>> GetAllFilmActors();
        Task<FilmActor> GetFilmActorById(int id);
        Task AddFilmActor(FilmActor filmActor);
        Task UpdateFilmActor(FilmActor filmActor);
        Task DeleteFilmActor(int id);
    }
}