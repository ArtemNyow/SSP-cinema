using BLL.Interfaces;
using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetUsers()
        {
            try
            {
                var tikets = await _ticketService.GetAll().ToListAsync();
                return Ok(tikets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Ticket>> AddUser([FromBody] Ticket ticket)
        {
            try
            {
                var addedTicket = await _ticketService.AddAsync(ticket);
                return Ok(addedTicket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteUser(int id)
        {
            try
            {
                var deletedTicket = await _ticketService.DeleteAsync(id);
                return Ok(deletedTicket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetUserById(int id)
        {
            try
            {
                var getTicketById = await _ticketService.GetByIdAsync(id);
                return Ok(getTicketById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> UpdateUser([FromBody] Ticket ticket)
        {
            try
            {
                var updatedTicket = await _ticketService.UpdateAsync(ticket);
                return Ok(updatedTicket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
