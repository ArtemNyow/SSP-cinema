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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IStatisticService _statisticService;
        public UsersController(IUserService userService, IStatisticService statisticService)
        {
            _userService = userService;
            _statisticService = statisticService;
        }

        [HttpGet]
        [Authorize("admin")]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            try
            {
                var users = await _userService
                    .GetAll()
                    .ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize("admin")]
        public async Task<ActionResult<UserDto>> Add([FromBody] CreateUser user)
        {
            try
            {
                var addedUser = await _userService.AddAsync(user);
                return Ok(addedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize("admin")]
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
            try
            {
                var deletedUser = await _userService.DeleteAsync(id);
                return Ok(deletedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [Authorize("admin")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            try
            {
                var getUserById = await _userService.GetByIdAsync(id);
                return Ok(getUserById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize("admin")]
        public async Task<ActionResult<UserDto>> Update([FromBody] UpdateUser user)
        {
            try
            {
                var updatedUser = await _userService.UpdateAsync(user);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("tickets")]
        [Authorize]
        public async Task<ActionResult<List<TicketDto>>> GetTickets()
        {
            try
            {
                int userId;
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (!int.TryParse(identity?.FindFirst("Jti")?.Value, out userId))
                {
                    return Unauthorized();
                }

                var userTickets = await _userService.GetTicketsByUserId(userId);
                return Ok(userTickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}/tickets")]
        [Authorize("admin")]
        public async Task<ActionResult<List<TicketDto>>> GetTicketsByUserId([FromQuery] int id)
        {
            try
            {
                var userTickets = await _userService.GetTicketsByUserId(id);
                return Ok(userTickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("recommendations")]
        [Authorize]
        public async Task<ActionResult<List<SessionDto>>> GetRecommendations()
        {
            try
            {
                int userId;
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (!int.TryParse(identity?.FindFirst("Jti")?.Value, out userId))
                {
                    return Unauthorized();
                }

                var userRecommendations = await _userService.GetPersonalRecommendations(userId);
                return Ok(userRecommendations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] Login login)
        {
            try
            {
                var jwtToken = await _userService.Login(login);
                return Ok(jwtToken);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpGet("{id}/statistic")]
        [Authorize("admin")]
        public async Task<ActionResult<UserStatistic>> GetStatisticById(int id)
        {
            try
            {
                var userStatistic = await _statisticService.GetUserStatisticById(id);
                return Ok(userStatistic);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost(template: "register")]
        public async Task<ActionResult> Register([FromBody] Register register)
        {
            try
            {
                await _userService.Register(register);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
