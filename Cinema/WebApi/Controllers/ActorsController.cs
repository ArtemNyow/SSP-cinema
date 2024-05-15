using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Actor>>> Get()
        {
            try
            {
                var actors = await _actorService.GetAll().ToListAsync();
                return Ok(actors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Actor>> Add([FromBody] Actor actor)
        {
            try
            {
                var addedActor = await _actorService.AddAsync(actor);
                return Ok(addedActor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Actor>> Delete(int id)
        {
            try
            {
                var deletedActor = await _actorService.DeleteAsync(id);
                return Ok(deletedActor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetById(int id)
        {
            try
            {
                var getActorById = await _actorService.GetByIdAsync(id);
                return Ok(getActorById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Actor>> Update([FromBody] Actor actor)
        {
            try
            {
                var updatedActor = await _actorService.UpdateAsync(actor);
                return Ok(updatedActor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
