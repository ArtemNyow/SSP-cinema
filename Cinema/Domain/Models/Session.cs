using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Session
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int HallID { get; set; }
        public int NumberOfSeats { get; set; }
        public float TicketPrice { get; set; }
        public string Status { get; set; }
        public int Occupancy { get; set; }
    }
}
