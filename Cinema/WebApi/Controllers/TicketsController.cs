using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;

        public TicketsController(
            ITicketService ticketService,
            IUserService userService)
        {
            _ticketService = ticketService;
            _userService = userService;
        }

        [HttpGet("all")]
        [Authorize("admin")]
        public async Task<ActionResult<List<TicketDto>>> GetAll()
        {
            try
            {
                var tickets = await _ticketService.GetAll().ToListAsync();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<TicketDto>> Get()
        {
            try
            {
                int userId;
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (!int.TryParse(identity?.FindFirst("Jti")?.Value, out userId))
                {
                    return Unauthorized();
                }

                var getTicketById = await _userService.GetTicketsByUserId(userId);
                return Ok(getTicketById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize("admin")]
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
        [Authorize("admin")]
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
        [Authorize("admin")]
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
        [Authorize("admin")]
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
