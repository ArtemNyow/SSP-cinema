using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories;

public class SessionRepository : GenericRepository<Session>, ISessionRepository
{
    public SessionRepository(CinemaDbContext dbContext) : base(dbContext)
    {
    }
}