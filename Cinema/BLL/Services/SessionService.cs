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
