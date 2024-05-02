using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(CinemaDbContext dbContext) : base(dbContext)
    {
    }
}