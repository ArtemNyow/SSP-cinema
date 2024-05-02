namespace Domain.Models
{
    public class Director : BaseEntity
    {
        public int PersonID { get; set; }
        public List<Movie> Movies { get; set; } = new();
        public Person Person { get; set; }
    }
}
