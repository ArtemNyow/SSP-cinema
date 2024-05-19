using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize("admin")]
        public async Task<ActionResult<List<ActorDto>>> Get()
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

        [HttpPost]
        [Authorize("admin")]
        public async Task<ActionResult<ActorDto>> Add([FromBody] ActorDto actor)
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
        [Authorize("admin")]
        public async Task<ActionResult<ActorDto>> Delete(int id)
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
        [Authorize("admin")]
        public async Task<ActionResult<ActorDto>> GetById(int id)
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

        [HttpPut]
        [Authorize("admin")]
        public async Task<ActionResult<ActorDto>> Update([FromBody] ActorDto actor)
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
