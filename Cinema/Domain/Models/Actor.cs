namespace Domain.Models
{
    internal class Actor
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public List<Movie> Movies { get; set; } = new();
        public Person Person { get; set; } 
    }
}
