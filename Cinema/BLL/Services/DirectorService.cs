using BLL.Interfaces;
using DAL.Interfaces;
using Domain.Models;

namespace BLL.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository DirectorRepository)
        {
            _directorRepository = DirectorRepository;
        }

        public async Task<Director> AddAsync(Director model)
        {
            ValidateDirector(model);

            Director entity = await _directorRepository.AddAsync(model);
            await _directorRepository.SaveAsync();

            return entity;
        }

        public async Task<Director> DeleteAsync(int id)
        {
            Director entity = await _directorRepository.DeleteAsync(id);
            await _directorRepository.SaveAsync();

            return entity;
        }

        public IQueryable<Director> GetAll()
        {
            return _directorRepository.GetAll();
        }

        public async Task<Director> GetByIdAsync(int id)
        {
            return await _directorRepository.GetAsync(id);
        }

        public async Task<Director> UpdateAsync(Director model)
        {
            ValidateDirector(model);

            Director entity = _directorRepository.Update(model);
            await _directorRepository.SaveAsync();

            return entity;
        }

        protected void ValidateDirector(Director director)
        {
            ArgumentNullException.ThrowIfNull(director);
        }
    }
}
