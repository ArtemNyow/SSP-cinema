using BLL.DTOs;
using Domain.Models;

namespace BLL.Mappers
{
    public static class TicketMapper
    {
        public static TicketDto ToDto(this Ticket ticket)
        {
            return new TicketDto
            {
                ID = ticket.ID,
                UserID = ticket.UserID,
                SessionID = ticket.SessionID,
                Price = ticket.Price,
                RowNumber = ticket.RowNumber,
                SeatNumber = ticket.SeatNumber,
            };
        }

        public static Ticket ToEntity(this TicketDto ticket)
        {
            return new Ticket
            {
                ID = ticket.ID,
                UserID = ticket.UserID,
                SessionID = ticket.SessionID,
                Price = ticket.Price,
                RowNumber = ticket.RowNumber,
                SeatNumber = ticket.SeatNumber,
            };
        }
    }
}
