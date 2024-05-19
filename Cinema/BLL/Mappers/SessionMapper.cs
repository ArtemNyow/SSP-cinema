using BLL.DTOs;
using Domain.Models;

namespace BLL.Mappers
{
    public static class SessionMapper
    {
        public static SessionDto ToDto(this Session session)
        {
            return new SessionDto
            {
                ID = session.ID,
                MovieID = session.MovieID,
                HallID = session.HallID,
                DateTime = session.DateTime,
                TicketPrice = session.TicketPrice,
                TicketVipPrice = session.TicketVipPrice,
                Status = session.Status.ToString(),
                Movie = session.Movie?.ToDto(),
                Hall = session.Hall?.ToDto(),
            };
        }

        public static Session ToEntity(this SessionDto session)
        {
            return new Session
            {
                ID = session.ID,
                MovieID = session.MovieID,
                HallID = session.HallID,
                DateTime = session.DateTime,
                TicketPrice = session.TicketPrice,
                TicketVipPrice = session.TicketVipPrice,
            };
        }
    }
}
