namespace Domain.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int AgeRating { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Trailer { get; set; }
        public List<Actor> Actors { get; set; } = new();
        public List<Director> Directors { get; set; } = new();
        public List<Genre> Genres { get; set; } = new();
        public List<Session> Sessions { get; set; } = new();
    }
}
