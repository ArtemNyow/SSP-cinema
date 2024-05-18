using BLL.DTOs;
using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        // GET: api/sessions
        [HttpGet]
        public async Task<ActionResult<List<SessionDto>>> Get(
            [FromQuery] DateOnly? dateFrom,
            [FromQuery] DateOnly? dateTo,
            [FromQuery] TimeOnly? timeFrom,
            [FromQuery] TimeOnly? timeTo,
            [FromQuery] int? minPrice,
            [FromQuery] int? maxPrice,
            [FromQuery] int? hallNumber,
            [FromQuery] string[]? movieGenres,
            [FromQuery] string? movieTitle)
        {
            try
            {
                SessionFilterSearch filter = new SessionFilterSearch()
                {
                    DateFrom = dateFrom ?? DateOnly.MinValue,
                    DateTo = dateTo ?? DateOnly.MaxValue,
                    TimeFrom = timeFrom ?? TimeOnly.MinValue,
                    TimeTo = timeTo ?? TimeOnly.MaxValue,
                    MinPrice = minPrice ?? 0,
                    MaxPrice = maxPrice ?? int.MaxValue,
                    HallNumber = hallNumber,
                    MovieGenres = movieGenres ?? Array.Empty<string>(),
                    MovieTitle = movieTitle,
                };

                var sessions = await _sessionService.GetByFilter(filter).ToListAsync();
                return Ok(sessions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/sessions/1
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDto>> GetById(int id)
        {
            try
            {
                var getSessionById = await _sessionService.GetByIdAsync(id);
                return Ok(getSessionById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/sessions
        [HttpPost]
        public async Task<ActionResult<SessionDto>> Add([FromBody] SessionDto session)
        {
            try
            {
                var addedSession = await _sessionService.AddAsync(session);
                return Ok(addedSession);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/sessions/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<SessionDto>> Delete(int id)
        {
            try
            {
                var deletedSession = await _sessionService.DeleteAsync(id);
                return Ok(deletedSession);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/sessions
        [HttpPut]
        public async Task<ActionResult<SessionDto>> Update([FromBody] SessionDto session)
        {
            try
            {
                var updatedSession = await _sessionService.UpdateAsync(session);
                return Ok(updatedSession);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        // GET: api/sessions/active
        [HttpGet("active")]
        public async Task<ActionResult<List<SessionDto>>> GetActiveSessions()
        {
            try
            {
                var activeSessions = await _sessionService
                    .GetActiveSessions()
                    .ToListAsync();
                return Ok(activeSessions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/sessions/active
        [HttpGet("{id}/book")]
        public async Task<ActionResult<TicketDto>> BookSeat(
            int id,
            [FromQuery] int rowNumber,
            [FromQuery] int seatNumber)
        {
            try
            {
                int userId;
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (!int.TryParse(identity?.FindFirst("Jti")?.Value, out userId))
                {
                    return Forbid();
                }

                var ticket = await _sessionService.BookSeat(id, userId, rowNumber, seatNumber);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
