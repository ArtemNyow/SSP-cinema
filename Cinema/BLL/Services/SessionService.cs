using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;
using Domain.Enums;
using Domain.Models;

namespace BLL.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository SessionRepository)
        {
            _sessionRepository = SessionRepository;
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
