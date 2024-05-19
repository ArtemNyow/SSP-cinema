using BLL.DTOs;
using Domain.Models;

namespace BLL.Mappers
{
    public static class ActorMapper
    {
        public static ActorDto ToDto(this Actor actor)
        {
            return new ActorDto
            {
                ID = actor.ID,
                PersonID = actor.PersonID,
                FirstName = actor.Person?.FirstName,
                LastName = actor.Person?.LastName,
            };
        }

        public static Actor ToEntity(this ActorDto actor)
        {
            return new Actor
            {
                ID = actor.ID,
                PersonID = actor.PersonID,
            };
        }
    }
}
