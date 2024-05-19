using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HallsController : ControllerBase
    {
        private readonly IHallService _hallService;
        public HallsController(IHallService hallService)
        {
            _hallService = hallService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HallDto>>> Get()
        {
            try
            {
                var halls = await _hallService.GetAll().ToListAsync();
                return Ok(halls);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<HallDto>> Add([FromBody] HallDto hall)
        {
            try
            {
                var addedHall = await _hallService.AddAsync(hall);
                return Ok(addedHall);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HallDto>> Delete(int id)
        {
            try
            {
                var deletedHall = await _hallService.DeleteAsync(id);
                return Ok(deletedHall);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HallDto>> GetById(int id)
        {
            try
            {
                var getHallById = await _hallService.GetByIdAsync(id);
                return Ok(getHallById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<HallDto>> Update([FromBody] HallDto hall)
        {
            try
            {
                var updatedHall = await _hallService.UpdateAsync(hall);
                return Ok(updatedHall);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
