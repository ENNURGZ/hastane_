using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane_.Entities
{
    [Table("Randevular")]
    public class Randevu
    {
        [Key]
        public Guid RandevuId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } //bir randevu bir hasta

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; } //bir randevu bir doktor
        
        public DateTime RandevuTarihi { get; set; } 

        [StringLength(50)]
        public string? Poliklinik { get; set; } = null;
        
        
        
    }
}
