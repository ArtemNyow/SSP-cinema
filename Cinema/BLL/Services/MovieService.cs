using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappers;
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

        public async Task<MovieDto> AddAsync(MovieDto model)
        {
            Movie movie = model.ToEntity();
            ValidateMovie(movie);

            Movie entity = await _movieRepository.AddAsync(movie);
            await _movieRepository.SaveAsync();

            return entity.ToDto();
        }

        public async Task<MovieDto> DeleteAsync(int id)
        {
            Movie entity = await _movieRepository.DeleteAsync(id);
            await _movieRepository.SaveAsync();

            return entity.ToDto();
        }

        public IQueryable<MovieDto> GetAll()
        {
            return _movieRepository
                .GetAll("Actors.Person", "Directors.Person", "Genres")
                .Select(m => m.ToDto());
        }

        public async Task<MovieDto> GetByIdAsync(int id)
        {
            return (await _movieRepository.GetAsync(id, "Actors.Person", "Directors.Person", "Genres")).ToDto();
        }

        public async Task<MovieDto> UpdateAsync(MovieDto model)
        {
            Movie movie = model.ToEntity();
            ValidateMovie(movie);

            Movie entity = _movieRepository.Update(movie);
            await _movieRepository.SaveAsync();

            return entity.ToDto();
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
