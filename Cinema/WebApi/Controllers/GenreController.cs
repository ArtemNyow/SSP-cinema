using BLL.Interfaces;
using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HallGenre : ControllerBase

    {
        private readonly IGenreService _genreService;
        public HallGenre(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetGenders()
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

        [HttpPut]
        public async Task<ActionResult<Genre>> AddGender([FromBody] Genre genre)
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
        public async Task<ActionResult<Genre>> DeleteGenre(int id)
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
        public async Task<ActionResult<Genre>> GetGenreById(int id)
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

        [HttpPost]
        public async Task<ActionResult<Genre>> UpdateHall([FromBody] Genre genre)
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
