using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane_.Entities
{
    [Table("Randevular")]
    public class Randevu
    {
        [Key]
        public Guid RandevuId { get; set; }
        public Guid Id { get; set; }
        public User User { get; set; } //bir randevu bir hasta
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; } //bir randevu bir doktor
        public DateTime RandevuGunu { get; set; }
        public TimeSpan RandevuSaati { get; set; }
    }
}