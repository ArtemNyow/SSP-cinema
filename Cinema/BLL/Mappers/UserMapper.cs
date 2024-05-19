using BLL.DTOs;
using Domain.Enums;
using Domain.Models;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                ID = user.ID,
                PersonID = user.PersonID,
                FirstName = user.Person?.FirstName,
                LastName = user.Person?.LastName,
                Email = user.Email,
                Role = user.Role.ToString(),
            };
        }

        public static User ToEntity(this CreateUser user)
        {
            return new User
            {
                PersonID = user.PersonID,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
            };
        }

        public static User ToEntity(this UpdateUser user)
        {
            return new User
            {
                ID = user.ID,
                PersonID = user.PersonID,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
            };
        }
    }
}
