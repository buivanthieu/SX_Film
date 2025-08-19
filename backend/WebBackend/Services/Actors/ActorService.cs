using AutoMapper;
using WebBackend.Dtos.Actors;
using WebBackend.Models;
using WebBackend.Repositories.Actors;

namespace WebBackend.Services.Actors
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorService(IActorRepository actorRepository, IMapper mapper)
        {
            _mapper = mapper;
            _actorRepository = actorRepository;
        }
        public async Task AddActor(CreateActorDto actorDto)
        {
            var actor = new Actor
            {
                Name = actorDto.Name,
                Description = actorDto.Description,
                DateOfBirth = actorDto.DateOfBirth,
                ImageUrl = actorDto.ImageUrl,
                Country = actorDto.Country
            };
            await _actorRepository.AddActor(actor);

        }

        public async Task DeleteActor(int id)
        {
            await _actorRepository.DeleteActor(id);
        }

        public async Task<GetActorDto?> GetActorById(int id)
        {
            var actor = await _actorRepository.GetActorById(id);
            return _mapper.Map<GetActorDto?>(actor);
        }

        public async Task<ICollection<GetActorDto>> GetActorsByFilmId(int filmId)
        {
            var actors = await _actorRepository.GetActorsByFilmId(filmId);
            return _mapper.Map<ICollection<GetActorDto>>(actors);
        }

        public async Task<ICollection<GetActorDto>> GetAllActors()
        {
            var actors = await _actorRepository.GetAllActors();
            return _mapper.Map<ICollection<GetActorDto>>(actors);
        }

        public async Task UpdateActor(int id, UpdateActorDto actorDto)
        {
            var actor = _mapper.Map<Actor>(actorDto);
            actor.Id = id;
            await _actorRepository.UpdateActor(actor);
        }
    }
}
