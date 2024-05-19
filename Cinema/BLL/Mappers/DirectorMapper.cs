using BLL.DTOs;
using Domain.Models;

namespace BLL.Mappers
{
    public static class DirectorMapper
    {
        public static DirectorDto ToDto(this Director director)
        {
            return new DirectorDto
            {
                ID = director.ID,
                PersonID = director.PersonID,
                FirstName = director.Person?.FirstName,
                LastName = director.Person?.LastName,
            };
        }

        public static Director ToEntity(this DirectorDto director)
        {
            return new Director
            {
                ID = director.ID,
                PersonID = director.PersonID,
            };
        }
    }
}
