using WebBackend.Dtos.Actors;
using WebBackend.Models;

namespace WebBackend.Services.Actors
{
    public interface IActorService
    {
        Task<ICollection<GetActorDto>> GetAllActors();
        Task<GetActorDto?> GetActorById(int id);
        Task<ICollection<GetActorDto>> GetActorsByFilmId(int filmId);
        Task AddActor(CreateActorDto actorDto);
        Task UpdateActor(int id, UpdateActorDto actorDto);
        Task DeleteActor(int id);
    }
}