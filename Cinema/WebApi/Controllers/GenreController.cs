using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [Authorize("admin")]
        public async Task<ActionResult<List<GenreDto>>> Get()
        {
            try
            {
                var genders = await _genreService.GetAll().ToListAsync();
                return Ok(genders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize("admin")]
        public async Task<ActionResult<GenreDto>> Add([FromBody] GenreDto genre)
        {
            try
            {
                var addedGender = await _genreService.AddAsync(genre);
                return Ok(addedGender);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize("admin")]
        public async Task<ActionResult<GenreDto>> Delete(int id)
        {
            try
            {
                var deletedGenre = await _genreService.DeleteAsync(id);
                return Ok(deletedGenre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [Authorize("admin")]
        public async Task<ActionResult<GenreDto>> GetById(int id)
        {
            try
            {
                var getGenreById = await _genreService.GetByIdAsync(id);
                return Ok(getGenreById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize("admin")]
        public async Task<ActionResult<GenreDto>> Update([FromBody] GenreDto genre)
        {
            try
            {
                var updatedGenre = await _genreService.UpdateAsync(genre);
                return Ok(updatedGenre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
