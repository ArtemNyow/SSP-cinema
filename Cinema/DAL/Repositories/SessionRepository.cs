using DAL.Interfaces;
using Domain.Enums;
using Domain.Models;

namespace DAL.Repositories;

public class SessionRepository : GenericRepository<Session>, ISessionRepository
{
    public SessionRepository(CinemaDbContext dbContext) : base(dbContext)
    {
        
    }

    public IQueryable<Session> GetActiveSessions()
    {
        return _dbSet.AsQueryable().Where(e => e.Status == SessionStatus.Active);
    }
}