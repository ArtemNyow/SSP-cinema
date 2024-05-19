using BLL.DTOs;
using Domain.Models;

namespace BLL.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto ToDto(this Movie movie)
        {
            return new MovieDto
            {
                ID = movie.ID,
                Title = movie.Title,
                Description = movie.Description,
                Rating = movie.Rating,
                AgeRating = movie.AgeRating,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate,
                Trailer = movie.Trailer,
                Actors = movie.Actors.Select(a => a.ToDto()),
                Directors = movie.Directors.Select(d => d.ToDto()),
                Genres = movie.Genres.Select(g => g.ToDto()),
            };
        }

        public static Movie ToEntity(this MovieDto movie)
        {
            return new Movie
            {
                ID = movie.ID,
                Title = movie.Title,
                Description = movie.Description,
                Rating = movie.Rating,
                AgeRating = movie.AgeRating,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate,
                Trailer = movie.Trailer,
            };
        }
    }
}
