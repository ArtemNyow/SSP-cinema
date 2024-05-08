using BLL.Interfaces;
using DAL.Interfaces;
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

        public async Task<Session> AddAsync(Session model)
        {
            ValidateSession(model);

            Session entity = await _sessionRepository.AddAsync(model);
            await _sessionRepository.SaveAsync();

            return entity;
        }

        public async Task<Session> DeleteAsync(int id)
        {
            Session entity = await _sessionRepository.DeleteAsync(id);
            await _sessionRepository.SaveAsync();

            return entity;
        }

        public IQueryable<Session> GetAll()
        {
            return _sessionRepository.GetAll();
        }

        public IQueryable<Session> GetByFilter(SessionFilterSearch filter)
        {
            IQueryable<Session> sessions = _sessionRepository.GetAll("Hall", "Movie.Genres");

            return sessions
                .Where(s =>
                    (filter.DateFrom == null || DateOnly.FromDateTime(s.DateTime) >= filter.DateFrom) &&
                    (filter.DateTo == null || DateOnly.FromDateTime(s.DateTime) <= filter.DateTo) &&
                    (filter.TimeFrom == null || TimeOnly.FromDateTime(s.DateTime) >= filter.TimeFrom) &&
                    (filter.TimeTo == null || TimeOnly.FromDateTime(s.DateTime) <= filter.TimeTo) &&
                    (filter.MinPrice == null || s.TicketPrice >= filter.MinPrice) &&
                    (filter.MaxPrice == null || s.TicketPrice <= filter.MaxPrice) &&
                    (filter.HallNumber == null || s.Hall.Number == filter.HallNumber) &&
                    (filter.MovieGenres == null || s.Movie.Genres.Any(g => filter.MovieGenres.Contains(g.Name))) &&
                    (filter.MovieTitle == null || s.Movie.Title.Contains(filter.MovieTitle)));
        }

        public Task<Session> GetByIdAsync(int id)
        {
            return _sessionRepository.GetAsync(id);
        }

        public async Task<Session> UpdateAsync(Session model)
        {
            ValidateSession(model);

            Session entity = _sessionRepository.Update(model);
            await _sessionRepository.SaveAsync();

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
