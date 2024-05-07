using BLL.Interfaces;
using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Director>>> GetDirectors()
        {
            try
            {
                var persons = await _directorService.GetAll().ToListAsync();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Director>> AddDirector([FromBody] Director director)
        {
            try
            {
                var addedDirector = await _directorService.AddAsync (director);
                return Ok(addedDirector);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Director>> DeleteDirector (int id)
        {
            try
            {
                var deletedDirector = await _directorService.DeleteAsync(id);
                return Ok(deletedDirector);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> GetDirectorById(int id)
        {
            try
            {
                var getDirectorById = await _directorService.GetByIdAsync(id);
                return Ok(getDirectorById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Director>> UpdateDirector([FromBody] Director director)
        {
            try
            {
                var updatedDirector = await _directorService.UpdateAsync(director);
                return Ok(updatedDirector);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
