using BLL.Interfaces;
using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovieController : ControllerBase 
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService) 
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetMovies()
        {
            try
            {
                var movies = _movieService.GetAll().ToList();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromBody]Movie movie)
        {
            try
            {
                var addedMovie  = await _movieService.AddAsync(movie);
                return Ok(addedMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
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
        public async Task<ActionResult<Movie>> GetMoviesById(int id)
        {
            try
            {
                var getMoviesById = await _movieService.GetByIdAsync(id);
                return Ok(getMoviesById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> UpdateMovie([FromBody] Movie movie)
        {
            try
            {
                var addedMovie = await _movieService.UpdateAsync(movie);
                return Ok(addedMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
