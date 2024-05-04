using BLL.Interfaces;
using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SessionController : ControllerBase

    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Session>>> GetSessions()
        {
            try
            {
                var sessions = await _sessionService.GetAll().ToListAsync();
                return Ok(sessions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Session>> AddSession([FromBody] Session session)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Session>> DeleteSession(int id)
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSessionById(int id)
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

        [HttpPost]
        public async Task<ActionResult<Session>> UpdateSession([FromBody] Session session)
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

    }
}
