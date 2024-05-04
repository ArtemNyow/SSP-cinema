using BLL.Interfaces;
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

        public async Task<Hall> AddAsync(Hall model)
        {
            ValidateHall(model);

            Hall entity = await _hallRepository.AddAsync(model);
            await _hallRepository.SaveAsync();

            return entity;
        }

        public async Task<Hall> DeleteAsync(int id)
        {
            Hall entity = await _hallRepository.DeleteAsync(id);
            await _hallRepository.SaveAsync();

            return entity;
        }

        public IQueryable<Hall> GetAll()
        {
            return _hallRepository.GetAll();
        }

        public Task<Hall> GetByIdAsync(int id)
        {
            return _hallRepository.GetAsync(id);
        }

        public async Task<Hall> UpdateAsync(Hall model)
        {
            ValidateHall(model);

            Hall entity = _hallRepository.Update(model);
            await _hallRepository.SaveAsync();

            return entity;
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
