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

        public async Task<Ticket> AddAsync(Ticket model)
        {
            ValidateTicket(model);

            Ticket entity = await _ticketRepository.AddAsync(model);
            await _ticketRepository.SaveAsync();

            return entity;
        }

        public async Task<Ticket> DeleteAsync(int id)
        {
            Ticket entity = await _ticketRepository.DeleteAsync(id);
            await _ticketRepository.SaveAsync();

            return entity;
        }

        public IQueryable<Ticket> GetAll()
        {
            return _ticketRepository.GetAll();
        }

        public Task<Ticket> GetByIdAsync(int id)
        {
            return _ticketRepository.GetAsync(id);
        }

        public async Task<Ticket> UpdateAsync(Ticket model)
        {
            ValidateTicket(model);

            Ticket entity = _ticketRepository.Update(model);
            await _ticketRepository.SaveAsync();

            return entity;
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
