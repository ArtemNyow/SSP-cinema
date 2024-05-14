using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Director>>> Get()
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
        public async Task<ActionResult<Director>> Add([FromBody] Director director)
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
        public async Task<ActionResult<Director>> Delete(int id)
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
        public async Task<ActionResult<Director>> GetById(int id)
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
        public async Task<ActionResult<Director>> Update([FromBody] Director director)
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
