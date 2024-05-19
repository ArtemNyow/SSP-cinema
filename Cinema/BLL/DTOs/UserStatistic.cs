namespace BLL.DTOs;

public class UserStatistic
{
    public UserDto User { get; set; }
    public decimal TotalSpending { get; set; }
    public int TotalTickets { get; set; }
    public List<GenreDto> FavoriteGenres { get; set; } = new();
}