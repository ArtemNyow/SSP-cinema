using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappers;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public class StatisticService : IStatisticService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IUserRepository _userRepository;
    
    public StatisticService(IMovieRepository movieRepository, IUserRepository userRepository)
    {
        _movieRepository = movieRepository;
        _userRepository = userRepository;
    }
    
    public async Task<MovieStatistic> GetMovieStatisticById(int id)
    {
        var movie = await _movieRepository.GetAsync(id, "Sessions.Tickets", "Sessions.Hall", "Actors.Person", "Genres", "Directors.Person");

        var totalProfit = movie.Sessions.Sum(s => s.Tickets.Sum(t => t.Price));

        var ticketsCount = movie.Sessions.Select(s => s.Tickets.Count);
        var sessionsHallsCapacity = movie.Sessions.Select(s => s.Hall.RowsCount * s.Hall.SeatsCountPerRow + s.Hall.RowsVipCount * s.Hall.SeatsVipCountPerRow);
        
        var averageValues = ticketsCount.Zip(sessionsHallsCapacity, (tickets, capacity) => (double)tickets / capacity);
        
        var attendancePercentage = Math.Round(averageValues.Average(), 2) * 100;

        var movieStatistic = new MovieStatistic()
        {
            Movie = movie.ToDto(),
            TotalProfit = totalProfit,
            AttendancePercentage = attendancePercentage,
        };

        return movieStatistic;
    }

    public async Task<UserStatistic> GetUserStatisticById(int id)
    {
        var user = await _userRepository.GetAsync(id, "Tickets.Session.Movie.Genres", "Person");

        var totalSpending = user.Tickets.Sum(t => t.Price);

        var totalTickets = user.Tickets.Count;

        var favoriteGenres = user.Tickets
            .SelectMany(t => t.Session.Movie.Genres)
            .GroupBy(genre => genre)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .Take(3)
            .ToList();

        var favoriteGenresDto = favoriteGenres.Select(g => g.ToDto()).ToList();

        var userStatistic = new UserStatistic()
        {
            User = user.ToDto(),
            TotalTickets = totalTickets,
            TotalSpending = totalSpending,
            FavoriteGenres = favoriteGenresDto,
        };

        return userStatistic;
    }
}