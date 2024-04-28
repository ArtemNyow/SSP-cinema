namespace Domain.Models
{
    public class Session
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int HallID { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TicketVipPrice { get; set; }
        public decimal TicketPrice { get; set; }
        public Movie Movie { get; set; }  
        public Hall Hall { get; set; }
    }
}
