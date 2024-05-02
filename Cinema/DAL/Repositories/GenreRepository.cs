using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(CinemaDbContext dbContext) : base(dbContext)
    {
    }
}