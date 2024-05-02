using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories;

public class HallRepository : GenericRepository<Hall>, IHallRepository
{
    public HallRepository(CinemaDbContext dbContext) : base(dbContext)
    {
    }
}