using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories;

public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
{
    public DirectorRepository(CinemaDbContext dbContext) : base(dbContext)
    {
    }
}