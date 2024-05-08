using BLL.Interfaces;
using DAL.Interfaces;
using Domain.Models;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IQueryable<Ticket> _ticketQuery;

        public UserService(IUserRepository userRepository, IPasswordHashService passwordHashService, IQueryable<Ticket> ticketQuery)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _ticketQuery = ticketQuery;
            _ticketQuery = ticketQuery;
        }

        public async Task<User> AddAsync(User model)
        {
            ValidateUser(model);

            model.Password = _passwordHashService.Hash(model.Password);

            User entity = await _userRepository.AddAsync(model);
            await _userRepository.SaveAsync();

            return entity;
        }

        public async Task<User> DeleteAsync(int id)
        {
            User entity = await _userRepository.DeleteAsync(id);
            await _userRepository.SaveAsync();

            return entity;
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Task<User> GetByIdAsync(int id)
        {
            return _userRepository.GetAsync(id);
        }

        public async Task<User> UpdateAsync(User model)
        {
            ValidateUser(model);

            model.Password = _passwordHashService.Hash(model.Password);

            User entity = _userRepository.Update(model);
            await _userRepository.SaveAsync();

            return entity;
        }

        public List<Ticket> GetTicketsByUserId(int userId)
        {
            return _ticketQuery.Where(ticket => ticket.UserID == userId).ToList();
        }

        protected void ValidateUser(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ArgumentException("User email must be valid.", nameof(user));
            }
            else if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ArgumentException("User password must be valid.", nameof(user));
            }
        }
    }
}
