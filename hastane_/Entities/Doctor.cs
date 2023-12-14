using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane_.Entities
{
    [Table("Doctors")]
    public class Doctor
    {
        [Key]
        public Guid DoctorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
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
        public string Role { get; set; } = "doctor";

        [StringLength(50)]
        public string? Poliklinik { get; set; } = null;
    
        public ICollection<Randevu> Randevular { get; set; } //bir doktor birden çok randevu
    }
}
