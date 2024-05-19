namespace BLL.DTOs;

public class MovieStatistic
{
    public MovieDto Movie { get; set; }
    public decimal TotalProfit { get; set; }
    public double AttendancePercentage { get; set; }
}