namespace BLL.DTOs
{
    public class SessionDto
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int HallID { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TicketVipPrice { get; set; }
        public decimal TicketPrice { get; set; }
        public string Status { get; set; }
        public MovieDto? Movie { get; set; }
        public HallDto? Hall { get; set; }
    }
}
