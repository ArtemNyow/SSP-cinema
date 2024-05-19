using BLL.DTOs;

namespace BLL.Interfaces;

public interface IStatisticService
{
    Task<MovieStatistic> GetMovieStatisticById(int id);
    Task<UserStatistic> GetUserStatisticById(int id);
}