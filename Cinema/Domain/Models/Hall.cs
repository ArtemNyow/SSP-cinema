using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    internal class Hall
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfSeeatsPreRow { get; set; }
        public string SeatType { get; set; }
    }
}
