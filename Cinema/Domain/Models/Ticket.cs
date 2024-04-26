using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Ticket
    {
        public int ID { get; set; }
        public int SessionID { get; set; }
        public string Seat { get; set; }
        public int UserID { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
    }
}
