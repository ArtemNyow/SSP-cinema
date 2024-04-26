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
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int AgeRating { get; set; }
        public string Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Trailers { get; set; }
    }
}
