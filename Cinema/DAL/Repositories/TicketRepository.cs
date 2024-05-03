using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories;

public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    public TicketRepository(CinemaDbContext dbContext) : base(dbContext)
    {
    }
}