using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(CinemaDbContext dbContext) : base(dbContext)
    {
    }
}