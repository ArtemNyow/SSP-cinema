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

        public async Task AddAsync(Actor model)
        {
            ValidateActor(model);

            await _actorRepository.AddAsync(model);
            await _actorRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _actorRepository.DeleteAsync(id);
            await _actorRepository.SaveAsync();
        }

        public IQueryable<Actor> GetAll()
        {
            return _actorRepository.GetAll();
        }

        public Task<Actor> GetByIdAsync(int id)
        {
            return _actorRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Actor model)
        {
            ValidateActor(model);

            _actorRepository.Update(model);
            await _actorRepository.SaveAsync();
        }

        protected void ValidateActor(Actor actor)
        {
            ArgumentNullException.ThrowIfNull(actor);
        }
    }
}
