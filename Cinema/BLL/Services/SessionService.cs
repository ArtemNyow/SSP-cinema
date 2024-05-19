using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;
using Domain.Enums;
using Domain.Models;
using System.Net;

namespace BLL.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;

        public SessionService(
            ISessionRepository sessionRepository, 
            ITicketService ticketService,
            IUserService userService)
        {
            _sessionRepository = sessionRepository;
            _ticketService = ticketService;
            _userService = userService;
        }

        public async Task<SessionDto> AddAsync(SessionDto model)
        {
            Session session = model.ToEntity();
            ValidateSession(session);

            Session entity = await _sessionRepository.AddAsync(session);
            await _sessionRepository.SaveAsync();

            return entity.ToDto();
        }

        public async Task<SessionDto> DeleteAsync(int id)
        {
            Session entity = await _sessionRepository.DeleteAsync(id);
            await _sessionRepository.SaveAsync();

            return entity.ToDto();
        }

        public IQueryable<SessionDto> GetAll()
        {
            return _sessionRepository
                .GetAll("Movie.Genres", "Hall", "Movie.Actors.Person", "Movie.Directors.Person")
                .Select(s => s.ToDto());
        }

        public IQueryable<SessionDto> GetByFilter(SessionFilterSearch filter)
        {
            IQueryable<Session> sessions = _sessionRepository
                .GetAll("Hall", "Movie.Genres", "Movie.Actors.Person", "Movie.Directors.Person");

            return sessions
                .Where(s =>
                    (s.DateTime >= filter.DateFrom.ToDateTime(TimeOnly.MinValue)) &&
                    (s.DateTime <= filter.DateTo.ToDateTime(TimeOnly.MinValue)) &&
                    (s.DateTime.TimeOfDay >= filter.TimeFrom.ToTimeSpan()) &&
                    (s.DateTime.TimeOfDay <= filter.TimeTo.ToTimeSpan()) &&
                    (s.TicketPrice >= filter.MinPrice) &&
                    (s.TicketPrice <= filter.MaxPrice) &&
                    (filter.HallNumber == null || s.Hall.Number == filter.HallNumber) &&
                    (filter.MovieGenres.Length == 0 || s.Movie.Genres.Any(g => filter.MovieGenres.Contains(g.Name))) &&
                    (filter.MovieActors.Length == 0 || s.Movie.Actors.Any(a => filter.MovieActors.Contains(a.Person.FirstName) || filter.MovieActors.Contains(a.Person.LastName))) &&
                    (filter.MovieDirectors.Length == 0 || s.Movie.Directors.Any(d => filter.MovieDirectors.Contains(d.Person.FirstName) || filter.MovieDirectors.Contains(d.Person.LastName))) &&                  
                    (filter.MovieTitle == null || s.Movie.Title.Contains(filter.MovieTitle, StringComparison.InvariantCultureIgnoreCase)))
                .Select(s => s.ToDto());
        }

        public IQueryable<SessionDto> GetActiveSessions()
        {
            return _sessionRepository
                .GetAll("Movie.Genre", "Hall", "Movie.Actors.Person", "Movie.Directors.Person")
                .Where(e => e.Status == SessionStatus.Active)
                .Select(s => s.ToDto());
        }

        public async Task<SessionDto> GetByIdAsync(int id)
        {
            return (await _sessionRepository
                    .GetAsync(id, "Movie.Genres", "Hall", "Movie.Actors.Person", "Movie.Directors.Person"))
                .ToDto();
        }

        public async Task<SessionDto> UpdateAsync(SessionDto model)
        {
            Session session = model.ToEntity();
            ValidateSession(session);

            Session entity = _sessionRepository.Update(session);
            await _sessionRepository.SaveAsync();

            return entity.ToDto();
        }

        public async Task<TicketDto> BookSeat(int sessionId, int userId, int rowNumber, int seatNumber)
        {
            var session = await _sessionRepository.GetAsync(sessionId, "Hall");
            if(session is null)
            {
                throw new HttpException("Session does not exist.", HttpStatusCode.BadRequest);
            }

            var user = await _userService.GetByIdAsync(userId);
            if (user is null)
            {
                throw new HttpException("User does not exist.", HttpStatusCode.BadRequest);
            }

            if (rowNumber < 1 || rowNumber > session.Hall.RowsCount + session.Hall.RowsVipCount)
            {
                throw new HttpException("Row number is invalid.", HttpStatusCode.BadRequest);
            }

            if (seatNumber < 0 ||
                rowNumber <= session.Hall.RowsCount && seatNumber > session.Hall.SeatsCountPerRow || 
                rowNumber <= session.Hall.RowsVipCount && seatNumber > session.Hall.SeatsVipCountPerRow)
            {
                throw new HttpException("Seat number is invalid.", HttpStatusCode.BadRequest);
            }

            var existingTicket = _ticketService
                .GetAll()
                .AsEnumerable()
                .FirstOrDefault(t => t.SeatNumber == seatNumber && t.RowNumber == rowNumber);
            if (existingTicket is not null)
            {
                throw new HttpException("Ticket with the same row and seat already exists.", HttpStatusCode.BadRequest);
            }

            bool isVip = rowNumber > session.Hall.RowsCount;

            TicketDto ticket = new TicketDto()
            {
                Price = isVip ? session.TicketVipPrice : session.TicketPrice,
                RowNumber = rowNumber,
                SeatNumber = seatNumber,
                SessionID = sessionId,
                UserID = userId,
            };

            TicketDto entity = await _ticketService.AddAsync(ticket);
            return entity;
        }

        protected void ValidateSession(Session session)
        {
            ArgumentNullException.ThrowIfNull(session);

            if (session.TicketPrice <= 0)
            {
                throw new ArgumentException("Session ticket price must be greater than 0.", nameof(session));
            }
            else if (session.TicketVipPrice < 0)
            {
                throw new ArgumentException("Session VIP ticket price must be non negative.", nameof(session));
            }
        }
    }
}
