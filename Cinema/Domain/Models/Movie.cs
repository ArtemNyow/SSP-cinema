using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public string description { get; set; }
        public int duration { get; set; }
        public int ageRating { get; set; }
        public string rating { get; set; }
        public DateTime releaseDate { get; set; }
        public string trailers { get; set; }
    }
}
