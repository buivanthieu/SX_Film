using WebBackend.Models;

namespace WebBackend.Repositories.Actors
{
    public interface IActorRepository
    {
        Task<ICollection<Actor>> GetAllActors();
        Task<Actor?> GetActorById(int id);
        Task<ICollection<Actor>> GetActorsByFilmId(int filmId);
        Task AddActor(Actor actor);
        Task UpdateActor(Actor actor);
        Task DeleteActor(int id);
    }
}