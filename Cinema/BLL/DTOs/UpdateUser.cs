using Domain.Enums;

namespace BLL.DTOs
{
    public class UpdateUser
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
