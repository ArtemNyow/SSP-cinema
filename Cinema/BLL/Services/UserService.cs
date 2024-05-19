using System.Net;
using System.Security.Authentication;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonService _personService;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IMovieRepository _movieRepository;
        private readonly IAuthService _authService;

        public UserService(
            IUserRepository userRepository, 
            IPersonService personService,
            IPasswordHashService passwordHashService,
            IMovieRepository movieRepository,
            IAuthService authService)
        {
            _userRepository = userRepository;
            _personService = personService;
            _passwordHashService = passwordHashService;
            _movieRepository = movieRepository;
            _authService = authService;
        }

        public async Task<UserDto> AddAsync(CreateUser model)
        {
            User user = model.ToEntity();
            ValidateUser(user);

            user.Password = _passwordHashService.Hash(user.Password);

            User entity = await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();

            return entity.ToDto();
        }

        public async Task<UserDto> DeleteAsync(int id)
        {
            User entity = await _userRepository.DeleteAsync(id);
            await _userRepository.SaveAsync();

            return entity.ToDto();
        }

        public IQueryable<UserDto> GetAll()
        {
            return _userRepository
                .GetAll("Person")
                .Select(u => u.ToDto());
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            return (await _userRepository.GetAsync(id, "Person")).ToDto();
        }

        public async Task<UserDto> UpdateAsync(UpdateUser model)
        {
            User user = model.ToEntity();
            ValidateUser(user);

            user.Password = _passwordHashService.Hash(user.Password);

            User entity = _userRepository.Update(user);
            await _userRepository.SaveAsync();

            return entity.ToDto();
        }

        public async Task<List<TicketDto>> GetTicketsByUserId(int id)
        {
            var user = await _userRepository.GetAsync(id, "Tickets");
            return user.Tickets.Select(t => t.ToDto()).ToList();
        }

        public async Task<List<SessionDto>> GetPersonalRecommendations(int id)
        {
            var user = await _userRepository.GetAsync(id, "Tickets.Session.Movie.Genres");

            var userMovies = user.Tickets.Select(t => t.Session.Movie);

            var genres = userMovies.SelectMany(m => m.Genres).Distinct();
            var ageRatings = userMovies.Select(m => m.AgeRating).Distinct();

            var allMovies = await _movieRepository
                .GetAll("Genres", "Sessions", "Hall")
                .ToListAsync();

            var recommendationMovies = allMovies
                .Where(movie => !userMovies.Any(m => m.Title == movie.Title))
                .Where(movie => movie.Genres.Exists(g => genres.Any(ge => ge.Name == g.Name)))
                .Where(movie => ageRatings.Any(rating => Math.Abs(movie.AgeRating - rating) <= 3));

            var sessions = recommendationMovies
                .SelectMany(movie => movie.Sessions
                    .Where(s => s.Status == SessionStatus.Active)
                    .Select(s => s.ToDto()))
                .ToList();

            return sessions;
        }

        public async Task<string> Login(Login login)
        {
            var user = await _userRepository
                .GetAll()
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user is null || !_passwordHashService.Verify(login.Password, user.Password))
            {
                throw new InvalidCredentialException();
            }

            var token = _authService.GenerateJwt(user);
            return token;
        }

        public async Task Register(Register register)
        {
            var user = await _userRepository
                .GetAll()
                .FirstOrDefaultAsync(u => u.Email == register.Email);

            if (user is not null)
            {
                throw new HttpException("Email already exists.", HttpStatusCode.BadRequest);
            }

            var person = await _personService.AddAsync(new Person
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
            });

            await AddAsync(new CreateUser
            {
                PersonID = person.ID,
                Email = register.Email,
                Password = register.Password,
                Role = UserRole.User,
            });
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
