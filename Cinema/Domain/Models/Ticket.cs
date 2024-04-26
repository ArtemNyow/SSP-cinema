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
        public int CustomerID { get; set; }
        public int Row_number { get; set; }
        public int Seat_number { get; set; }
        public int Price { get; set; }
        
    }
}
