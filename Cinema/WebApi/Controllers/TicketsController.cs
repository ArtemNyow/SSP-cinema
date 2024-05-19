using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TicketDto>>> Get()
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

        [HttpPost]
        public async Task<ActionResult<TicketDto>> Add([FromBody] TicketDto ticket)
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
        public async Task<ActionResult<TicketDto>> Delete(int id)
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
        public async Task<ActionResult<TicketDto>> GetById(int id)
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

        [HttpPut]
        public async Task<ActionResult<TicketDto>> Update([FromBody] TicketDto ticket)
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
