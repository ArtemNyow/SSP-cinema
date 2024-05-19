using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;
using Domain.Models;

namespace BLL.Services
{
    public class HallService : IHallService
    {
        private readonly IHallRepository _hallRepository;

        public HallService(IHallRepository HallRepository)
        {
            _hallRepository = HallRepository;
        }

        public async Task<HallDto> AddAsync(HallDto model)
        {
            Hall hall = model.ToEntity();
            ValidateHall(hall);

            Hall entity = await _hallRepository.AddAsync(hall);
            await _hallRepository.SaveAsync();

            return entity.ToDto();
        }

        public async Task<HallDto> DeleteAsync(int id)
        {
            Hall entity = await _hallRepository.DeleteAsync(id);
            await _hallRepository.SaveAsync();

            return entity.ToDto();
        }

        public IQueryable<HallDto> GetAll()
        {
            return _hallRepository
                .GetAll()
                .Select(h => h.ToDto());
        }

        public async Task<HallDto> GetByIdAsync(int id)
        {
            return (await _hallRepository.GetAsync(id)).ToDto();
        }

        public async Task<HallDto> UpdateAsync(HallDto model)
        {
            Hall hall = model.ToEntity();
            ValidateHall(hall);

            Hall entity = _hallRepository.Update(hall);
            await _hallRepository.SaveAsync();

            return entity.ToDto();
        }

        protected void ValidateHall(Hall hall)
        {
            ArgumentNullException.ThrowIfNull(hall);

            if (hall.Number <= 0)
            {
                throw new ArgumentException("Hall number must be greater than 0.", nameof(hall));
            }
            else if (hall.RowsCount <= 0)
            {
                throw new ArgumentException("Hall row count must be greater than 0.", nameof(hall));
            }
            else if (hall.SeatsCountPerRow <= 0)
            {
                throw new ArgumentException("Hall seats count per row must be greater than 0.", nameof(hall));
            }
            else if (hall.RowsVipCount > 0 && hall.SeatsVipCountPerRow <= 0)
            {
                throw new ArgumentException(
                    "Hall VIP seats count per row must be greater than 0 when VIP rows count is greater than 0.", 
                    nameof(hall));
            }
        }
    }
}
