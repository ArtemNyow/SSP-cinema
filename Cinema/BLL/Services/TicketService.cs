using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappers;
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

        public async Task<TicketDto> AddAsync(TicketDto model)
        {
            Ticket ticket = model.ToEntity();
            ValidateTicket(ticket);

            Ticket entity = await _ticketRepository.AddAsync(ticket);
            await _ticketRepository.SaveAsync();

            return entity.ToDto();
        }

        public async Task<TicketDto> DeleteAsync(int id)
        {
            Ticket entity = await _ticketRepository.DeleteAsync(id);
            await _ticketRepository.SaveAsync();

            return entity.ToDto();
        }

        public IQueryable<TicketDto> GetAll()
        {
            return _ticketRepository
                .GetAll()
                .Select(s => s.ToDto());
        }

        public async Task<TicketDto> GetByIdAsync(int id)
        {
            return (await _ticketRepository.GetAsync(id)).ToDto();
        }

        public async Task<TicketDto> UpdateAsync(TicketDto model)
        {
            Ticket ticket = model.ToEntity();
            ValidateTicket(ticket);

            Ticket entity = _ticketRepository.Update(ticket);
            await _ticketRepository.SaveAsync();

            return entity.ToDto();
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
