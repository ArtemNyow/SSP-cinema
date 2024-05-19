using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IStatisticService _statisticService;
        public MoviesController(IMovieService movieService, IStatisticService statisticService)
        {
            _movieService = movieService;
            _statisticService = statisticService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDto>>> Get()
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

        [HttpPost]
        public async Task<ActionResult<MovieDto>> Add([FromBody] MovieDto movie)
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
        public async Task<ActionResult<MovieDto>> Delete(int id)
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
        public async Task<ActionResult<MovieDto>> GetById(int id)
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

        [HttpPut]
        public async Task<ActionResult<MovieDto>> Update([FromBody] MovieDto movie)
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

        [HttpGet("{id}/statistic")]
        public async Task<ActionResult<MovieStatistic>> GetStatisticById(int id)
        {
            try
            {
                var getUserById = await _statisticService.GetMovieStatisticById(id);
                return Ok(getUserById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
