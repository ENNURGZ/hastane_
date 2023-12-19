using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane_.Entities
{
    [Table("Doctors")]
    public class Doctor
    {

        [Key]
        public Guid DoctorId { get; set; }

        //[ForeignKey("Id")]
        public Guid Id { get; set; }
        public User User { get; set; }
        public int PoliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; }
        public Guid CalismaSaatiId { get; set; }
        public CalismaSaati CalismaSaati { get; set; }

        public ICollection<Randevu>? Randevular { get; set; } //bir doktor birden çok randevu
    }
}
