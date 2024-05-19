using BLL.DTOs;
using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{id}/tickets")]
        public async Task<ActionResult<List<TicketDto>>> GetTicketbyUserId(int id)
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

        [HttpGet("{id}/recommendations")]
        public async Task<ActionResult<List<SessionDto>>> GetRecommendations(int id)
        {
            try
            {
                var userRecommendations = await _userService.GetPersonalRecommendations(id);
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
                var jwtToken = await _userService.Login(login.Email, login.Password);
                return Ok(jwtToken);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpGet("{id}/statistic")]
        public async Task<ActionResult<UserStatistic>> GetStatisticById(int id)
        {
            try
            {
                var getUserById = await _statisticService.GetUserStatisticById(id);
                return Ok(getUserById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
