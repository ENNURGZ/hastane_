using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane_.Entities
{
    [Table("Adminler")]
    public class Admin
    {
        [Key]
        public Guid AdminId { get; set; } 

        [Required]
        [StringLength(100)]
        public string Name { get; set; } 
        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public bool Locked { get; set; } = false;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "admin";
    }
}