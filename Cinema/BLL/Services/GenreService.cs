using BLL.Interfaces;
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

        public async Task<Genre> AddAsync(Genre model)
        {
            ValidateGenre(model);

            Genre entity = await _genreRepository.AddAsync(model);
            await _genreRepository.SaveAsync();

            return entity;
        }

        public async Task<Genre> DeleteAsync(int id)
        {
            Genre entity = await _genreRepository.DeleteAsync(id);
            await _genreRepository.SaveAsync();

            return entity;
        }

        public IQueryable<Genre> GetAll()
        {
            return _genreRepository.GetAll();
        }

        public Task<Genre> GetByIdAsync(int id)
        {
            return _genreRepository.GetAsync(id);
        }

        public async Task<Genre> UpdateAsync(Genre model)
        {
            ValidateGenre(model);

            Genre entity = _genreRepository.Update(model);
            await _genreRepository.SaveAsync();

            return entity;
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
