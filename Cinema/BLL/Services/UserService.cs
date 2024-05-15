using System.Security.Authentication;
using BLL.Interfaces;
using DAL.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IMovieRepository _movieRepository;
        private readonly IAuthService _authService;

        public UserService(
            IUserRepository userRepository,
            IPasswordHashService passwordHashService,
            IMovieRepository movieRepository,
            IAuthService authService)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _movieRepository = movieRepository;
            _authService = authService;
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

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<User> UpdateAsync(User model)
        {
            ValidateUser(model);

            model.Password = _passwordHashService.Hash(model.Password);

            User entity = _userRepository.Update(model);
            await _userRepository.SaveAsync();

            return entity;
        }

        public async Task<List<Ticket>> GetTicketsByUserId(int id)
        {
            var user = await _userRepository.GetAsync(id, "Tickets");
            return user.Tickets;
        }

        public async Task<List<Session>> GetPersonalRecommendations(int id)
        {
            var user = await _userRepository.GetAsync(id, "Tickets.Session.Movie.Genres");

            var userMovies = from Ticket in user.Tickets
                             select Ticket.Session.Movie;

            var genres = userMovies.SelectMany(m => m.Genres);
            var ageRatings = userMovies.Select(m => m.AgeRating);

            var allMovies = await _movieRepository.GetAll().ToListAsync();

            var recommendationMovies = allMovies
                .Where(movie => !userMovies.Any(m => m.Title == movie.Title))
                .Where(movie => movie.Genres.Any(g => genres.Any(ge => ge.Name == g.Name)))
                .Where(movie => ageRatings.Any(rating => Math.Abs(movie.AgeRating - rating) <= 3))
                .ToList();

            var sessions = recommendationMovies
                .SelectMany(movie => movie.Sessions
                .Where(s => s.Status == SessionStatus.Active))
                .ToList();

            return sessions;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Email == email);

            if (user is null || !_passwordHashService.Verify(user.Password, password))
            {
                throw new InvalidCredentialException();
            }

            var token = _authService.GenerateJwt(user);
            return token;
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
