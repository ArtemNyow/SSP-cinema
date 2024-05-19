using BLL.DTOs;
using Domain.Models;

namespace BLL.Mappers
{
    public static class GenreMapper
    {
        public static GenreDto ToDto(this Genre genre)
        {
            return new GenreDto
            {
                ID = genre.ID,
                Name = genre.Name,
            };
        }

        public static Genre ToEntity(this GenreDto genre)
        {
            return new Genre
            {
                ID = genre.ID,
                Name = genre.Name,
            };
        }
    }
}
