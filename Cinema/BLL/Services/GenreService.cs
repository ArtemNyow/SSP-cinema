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

        public async Task AddAsync(Genre model)
        {
            ValidateGenre(model);

            await _genreRepository.AddAsync(model);
            await _genreRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _genreRepository.DeleteAsync(id);
            await _genreRepository.SaveAsync();
        }

        public IQueryable<Genre> GetAll()
        {
            return _genreRepository.GetAll();
        }

        public Task<Genre> GetByIdAsync(int id)
        {
            return _genreRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Genre model)
        {
            ValidateGenre(model);

            _genreRepository.Update(model);
            await _genreRepository.SaveAsync();
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
