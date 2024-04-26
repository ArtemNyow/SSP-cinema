namespace Domain.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int AgeRating { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Trailer { get; set; }
    }
}
