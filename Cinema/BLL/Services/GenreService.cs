using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;
using Domain.Models;

namespace BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository GenreRepository)
        {
            _genreRepository = GenreRepository;
        }

        public async Task<GenreDto> AddAsync(GenreDto model)
        {
            Genre genre = model.ToEntity();
            ValidateGenre(genre);

            Genre entity = await _genreRepository.AddAsync(genre);
            await _genreRepository.SaveAsync();

            return entity.ToDto();
        }

        public async Task<GenreDto> DeleteAsync(int id)
        {
            Genre entity = await _genreRepository.DeleteAsync(id);
            await _genreRepository.SaveAsync();

            return entity.ToDto();
        }

        public IQueryable<GenreDto> GetAll()
        {
            return _genreRepository
                .GetAll()
                .Select(h => h.ToDto());
        }

        public async Task<GenreDto> GetByIdAsync(int id)
        {
            return (await _genreRepository.GetAsync(id)).ToDto();
        }

        public async Task<GenreDto> UpdateAsync(GenreDto model)
        {
            Genre genre = model.ToEntity();
            ValidateGenre(genre);

            Genre entity = _genreRepository.Update(genre);
            await _genreRepository.SaveAsync();

            return entity.ToDto();
        }

        protected void ValidateGenre(Genre genre)
        {
            ArgumentNullException.ThrowIfNull(genre);

            if (string.IsNullOrWhiteSpace(genre.Name))
            {
                throw new ArgumentException("Genre name must be valid.", nameof(genre));
            }
        }
    }
}
