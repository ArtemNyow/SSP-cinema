using Domain.Models;

namespace DAL.Interfaces;

public interface ISessionRepository : IGenericRepository<Session>
{
    public IQueryable<Session> GetActiveSessions();
}