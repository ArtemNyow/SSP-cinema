using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public Session Session { get; set; }
        public User User { get; set; }
        
    }
}
