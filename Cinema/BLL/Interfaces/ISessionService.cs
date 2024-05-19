using BLL.DTOs;
using Domain.Models;

namespace BLL.Interfaces
{
    public interface ISessionService : ICrud<SessionDto>
    {
        public IQueryable<SessionDto> GetByFilter(SessionFilterSearch filter);
        public IQueryable<SessionDto> GetActiveSessions();
        public Task<TicketDto> BookSeat(int sessionId, int userId, int rowNumber, int seatNumber);
    }
}
