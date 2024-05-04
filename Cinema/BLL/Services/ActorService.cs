using BLL.Interfaces;
using DAL.Interfaces;
using Domain.Models;

namespace BLL.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository ActorRepository)
        {
            _actorRepository = ActorRepository;
        }

        public async Task<Actor> AddAsync(Actor model)
        {
            ValidateActor(model);

            Actor entity = await _actorRepository.AddAsync(model);
            await _actorRepository.SaveAsync();

            return entity;
        }

        public async Task<Actor> DeleteAsync(int id)
        {
            Actor entity = await _actorRepository.DeleteAsync(id);
            await _actorRepository.SaveAsync();

            return entity;
        }

        public IQueryable<Actor> GetAll()
        {
            return _actorRepository.GetAll();
        }

        public Task<Actor> GetByIdAsync(int id)
        {
            return _actorRepository.GetAsync(id);
        }

        public async Task<Actor> UpdateAsync(Actor model)
        {
            ValidateActor(model);

            Actor entity = _actorRepository.Update(model);
            await _actorRepository.SaveAsync();

            return entity;
        }

        protected void ValidateActor(Actor actor)
        {
            ArgumentNullException.ThrowIfNull(actor);
        }
    }
}
