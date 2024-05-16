using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappers;
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

        public async Task<DirectorDto> AddAsync(DirectorDto model)
        {
            Director director = model.ToEntity();
            ValidateDirector(director);

            Director entity = await _directorRepository.AddAsync(director);
            await _directorRepository.SaveAsync();

            return entity.ToDto();
        }

        public async Task<DirectorDto> DeleteAsync(int id)
        {
            Director entity = await _directorRepository.DeleteAsync(id);
            await _directorRepository.SaveAsync();

            return entity.ToDto();
        }

        public IQueryable<DirectorDto> GetAll()
        {
            return _directorRepository
                .GetAll("Person")
                .Select(d => d.ToDto());
        }

        public async Task<DirectorDto> GetByIdAsync(int id)
        {
            return (await _directorRepository.GetAsync(id, "Person")).ToDto();
        }

        public async Task<DirectorDto> UpdateAsync(DirectorDto model)
        {
            Director director = model.ToEntity();
            ValidateDirector(director);

            Director entity = _directorRepository.Update(director);
            await _directorRepository.SaveAsync();

            return entity.ToDto();
        }

        protected void ValidateDirector(Director director)
        {
            ArgumentNullException.ThrowIfNull(director);
        }
    }
}
