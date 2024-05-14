using BLL.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            try
            {
                var movies = await _movieService.GetAll().ToListAsync();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Movie>> Add([FromBody] Movie movie)
        {
            try
            {
                var addedMovie = await _movieService.AddAsync(movie);
                return Ok(addedMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> Delete(int id)
        {
            try
            {
                var deletedMovie = await _movieService.DeleteAsync(id);
                return Ok(deletedMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetById(int id)
        {
            try
            {
                var getMovieById = await _movieService.GetByIdAsync(id);
                return Ok(getMovieById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> Update([FromBody] Movie movie)
        {
            try
            {
                var updatedMovie = await _movieService.UpdateAsync(movie);
                return Ok(updatedMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
