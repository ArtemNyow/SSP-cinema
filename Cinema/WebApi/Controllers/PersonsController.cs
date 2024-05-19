using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Authorize("admin")]
        public async Task<ActionResult<List<Person>>> Get()
        {
            try
            {
                var persons = await _personService.GetAll().ToListAsync();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize("admin")]
        public async Task<ActionResult<Person>> Add([FromBody] Person person)
        {
            try
            {
                person.ID = 0;
                var addedPerson = await _personService.AddAsync(person);
                return Ok(addedPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize("admin")]
        public async Task<ActionResult<Person>> Delete(int id)
        {
            try
            {
                var deletedPerson = await _personService.DeleteAsync(id);
                return Ok(deletedPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [Authorize("admin")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            try
            {
                var getPersonById = await _personService.GetByIdAsync(id);
                return Ok(getPersonById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize("admin")]
        public async Task<ActionResult<Person>> Update([FromBody] Person person)
        {
            try
            {
                var updatedPerson = await _personService.UpdateAsync(person);
                return Ok(updatedPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
