using Domain.Enums;

namespace Domain.Models
{
    public class Session : BaseEntity
    {
        public int MovieID { get; set; }
        public int HallID { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TicketVipPrice { get; set; }
        public decimal TicketPrice { get; set; }
        public SessionStatus Status { get; set; }
        public Movie Movie { get; set; }  
        public Hall Hall { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}
