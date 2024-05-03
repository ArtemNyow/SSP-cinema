namespace Domain.Models
{
    public class Actor : BaseEntity
    {
        public int PersonID { get; set; }
        public List<Movie> Movies { get; set; } = new();
        public Person Person { get; set; } 
    }
}
