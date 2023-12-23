using System.ComponentModel.DataAnnotations;
namespace hastane_.Models
{
    public class AdminListViewModel
    {
        public Guid AdminId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public bool Locked { get; set; } = false;
    }
}
