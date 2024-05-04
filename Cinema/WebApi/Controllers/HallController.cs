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
    public class HallController : ControllerBase

    {
        private readonly IHallService _hallService;
        public HallController(IHallService hallService)
        {
            _hallService = hallService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hall>>> GetHalls()
        {
            try
            {
                var halls = await _hallService.GetAll().ToListAsync();
                return Ok(halls);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Hall>> AddHall([FromBody] Hall hall)
        {
            try
            {
                var addedHall = await _hallService.AddAsync(hall);
                return Ok(addedHall);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Hall>> DeleteHall(int id)
        {
            try
            {
                var deletedHall = await _hallService.DeleteAsync(id);
                return Ok(deletedHall);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hall>> GetHallById(int id)
        {
            try
            {
                var getHallById = await _hallService.GetByIdAsync(id);
                return Ok(getHallById);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Hall>> UpdateHall([FromBody] Hall hall)
        {
            try
            {
                var updatedHall = await _hallService.UpdateAsync(hall);
                return Ok(updatedHall);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
