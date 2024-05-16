namespace BLL.DTOs
{
    public class MovieDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int AgeRating { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Trailer { get; set; }
        public IEnumerable<ActorDto> Actors { get; set; }
        public IEnumerable<DirectorDto> Directors { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
    }
}
