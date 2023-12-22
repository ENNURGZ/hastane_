using System.ComponentModel.DataAnnotations;

namespace hastane_.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public bool Locked { get; set; } = false;
        public string Role { get; set; } = "user";
    }
}
