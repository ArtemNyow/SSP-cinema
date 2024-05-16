using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IQueryable<UserDto> GetAll();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> AddAsync(CreateUser model);
        Task<UserDto> UpdateAsync(UpdateUser model);
        Task<UserDto> DeleteAsync(int id);

        Task<List<TicketDto>> GetTicketsByUserId(int id);
        Task<List<SessionDto>> GetPersonalRecommendations(int id);
        Task<string> Login(string email, string password);
    }
}
