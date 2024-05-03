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

        public async Task AddAsync(Director model)
        {
            ValidateDirector(model);

            await _directorRepository.AddAsync(model);
            await _directorRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _directorRepository.DeleteAsync(id);
            await _directorRepository.SaveAsync();
        }

        public IQueryable<Director> GetAll()
        {
            return _directorRepository.GetAll();
        }

        public Task<Director> GetByIdAsync(int id)
        {
            return _directorRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Director model)
        {
            ValidateDirector(model);

            _directorRepository.Update(model);
            await _directorRepository.SaveAsync();
        }

        protected void ValidateDirector(Director director)
        {
            ArgumentNullException.ThrowIfNull(director);
        }
    }
}
