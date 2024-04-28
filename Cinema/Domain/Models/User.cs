using Domain.Enums;

namespace Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role {  get; set; }  
        public Person Person { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
    }
}
