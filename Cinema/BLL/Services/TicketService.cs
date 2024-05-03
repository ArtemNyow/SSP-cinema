using BLL.Interfaces;
using DAL.Interfaces;
using Domain.Models;

namespace BLL.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository TicketRepository)
        {
            _ticketRepository = TicketRepository;
        }

        public async Task AddAsync(Ticket model)
        {
            ValidateTicket(model);

            await _ticketRepository.AddAsync(model);
            await _ticketRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _ticketRepository.DeleteAsync(id);
            await _ticketRepository.SaveAsync();
        }

        public IQueryable<Ticket> GetAll()
        {
            return _ticketRepository.GetAll();
        }

        public Task<Ticket> GetByIdAsync(int id)
        {
            return _ticketRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Ticket model)
        {
            ValidateTicket(model);

            _ticketRepository.Update(model);
            await _ticketRepository.SaveAsync();
        }

        protected void ValidateTicket(Ticket ticket)
        {
            ArgumentNullException.ThrowIfNull(ticket);

            if (ticket.RowNumber <= 0)
            {
                throw new ArgumentException("Ticket row number must be greater than 0.", nameof(ticket));
            }
            else if (ticket.SeatNumber <= 0)
            {
                throw new ArgumentException("Ticket seat number must be greater than 0.", nameof(ticket));
            }
            else if (ticket.Price <= 0)
            {
                throw new ArgumentException("Ticket price must be greater than 0.", nameof(ticket));
            }
        }
    }
}
