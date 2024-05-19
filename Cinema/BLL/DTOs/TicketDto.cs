namespace BLL.DTOs
{
    public class TicketDto
    {
        public int ID { get; set; }
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
    }
}
