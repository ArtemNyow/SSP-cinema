using BLL.Interfaces;
using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Actor>>> GetActors()
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
        public async Task<ActionResult<Actor>> AddActor([FromBody] Actor actor)
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
        public async Task<ActionResult<Actor>> DeleteActor(int id)
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
        public async Task<ActionResult<Actor>> GetActorById(int id)
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
        public async Task<ActionResult<Actor>> UpdatePerson([FromBody] Actor actor)
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
