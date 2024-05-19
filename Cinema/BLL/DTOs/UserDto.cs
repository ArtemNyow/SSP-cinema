namespace BLL.DTOs
{
    public class UserDto
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
