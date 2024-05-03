using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories;

public class ActorRepository : GenericRepository<Actor>, IActorRepository
{
    public ActorRepository(CinemaDbContext dbContext) : base(dbContext)
    {
    }
}