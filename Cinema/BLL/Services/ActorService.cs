using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappers;
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

        public async Task<ActorDto> AddAsync(ActorDto model)
        {
            Actor actor = model.ToEntity();
            ValidateActor(actor);

            Actor entity = await _actorRepository.AddAsync(actor);
            await _actorRepository.SaveAsync();

            return entity.ToDto();
        }

        public async Task<ActorDto> DeleteAsync(int id)
        {
            Actor entity = await _actorRepository.DeleteAsync(id);
            await _actorRepository.SaveAsync();

            return entity.ToDto();
        }

        public IQueryable<ActorDto> GetAll()
        {
            return _actorRepository
                .GetAll("Person")
                .Select(a => a.ToDto());
        }

        public async Task<ActorDto> GetByIdAsync(int id)
        {
            return (await _actorRepository.GetAsync(id, "Person")).ToDto();
        }

        public async Task<ActorDto> UpdateAsync(ActorDto model)
        {
            Actor actor = model.ToEntity();
            ValidateActor(actor);

            Actor entity = _actorRepository.Update(actor);
            await _actorRepository.SaveAsync();

            return entity.ToDto();
        }

        protected void ValidateActor(Actor actor)
        {
            ArgumentNullException.ThrowIfNull(actor);
        }
    }
}
