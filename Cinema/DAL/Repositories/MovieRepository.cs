using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(CinemaDbContext dbContext) : base(dbContext)
    {
    }
}