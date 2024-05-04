using BLL.Interfaces;
using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase

    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons()
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

        [HttpPut]
        public async Task<ActionResult<Person>> AddPerson([FromBody] Person person)
        {
            try
            {
                var addedPerson = await _personService.AddAsync(person);
                return Ok(addedPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
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
        public async Task<ActionResult<Person>> GetPersonById(int id)
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

        [HttpPost]
        public async Task<ActionResult<Person>> UpdatePerson([FromBody] Person person)
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
