using BLL.Interfaces;
using DAL.Interfaces;
using Domain.Models;

namespace BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task AddAsync(Movie model)
        {
            ValidateMovie(model);

            await _movieRepository.AddAsync(model);
            await _movieRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _movieRepository.DeleteAsync(id);
            await _movieRepository.SaveAsync();
        }

        public IQueryable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            return _movieRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Movie model)
        {
            ValidateMovie(model);

            _movieRepository.Update(model);
            await _movieRepository.SaveAsync();
        }

        protected void ValidateMovie(Movie movie)
        {
            ArgumentNullException.ThrowIfNull(movie);

            if (string.IsNullOrWhiteSpace(movie.Title))
            {
                throw new ArgumentException("Movie title must be valid.", nameof(movie));
            }
            else if (movie.Duration <= 0)
            {
                throw new ArgumentException("Movie duration must be greater than 0.", nameof(movie));
            }
            else if (movie.AgeRating < 0)
            {
                throw new ArgumentException("Movie age rating must be non negative.", nameof(movie));
            }
            else if (movie.Rating < 0)
            {
                throw new ArgumentException("Movie rating must be non negative.", nameof(movie));
            }
        }
    }
}
