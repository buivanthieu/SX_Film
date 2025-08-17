using Microsoft.EntityFrameworkCore;
using WebBackend.Datas;
using WebBackend.Models;

namespace WebBackend.Repositories.Actors
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;
        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddActor(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActor(int id)
        {
            var actor = await _context.Actors.FindAsync(id)
                ?? throw new KeyNotFoundException();
            _context.Actors.Remove(actor);
        }

        public async Task<Actor?> GetActorById(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            return actor;
        }

        public async Task<ICollection<Actor>> GetActorsByFilmId(int filmId)
        {
            var actorList = await _context.Actors
                .Where(a => a.FilmActors.Any(fa => fa.FilmId == filmId))
                .ToListAsync();
            return actorList;
        }

        public async Task<ICollection<Actor>> GetAllActors()
        {
            var actorList = await _context.Actors.ToListAsync();
            return actorList;
        }

        public async Task UpdateActor(Actor actor)
        {
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
        }
    }
}
