using Domain.Models;

namespace BLL.Interfaces
{
    public interface IUserService : ICrud<User>
    {
        Task<List<Ticket>> GetTicketsByUserId(int id);
    }
}
