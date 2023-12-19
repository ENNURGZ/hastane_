using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane_.Entities
{
    [Table("Randevular")]
    public class Randevu
    {
        [Key]
        public Guid RandevuId { get; set; }

        //[ForeignKey("HastaId")]
        public Guid HastaId { get; set; }
        public Hasta Hasta { get; set; } //bir randevu bir hasta

        //[ForeignKey("DoctorId")]
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; } //bir randevu bir doktor
        
        public DateTime RandevuTarihi { get; set; } 

        [StringLength(50)]
        public int PoliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; }



    }
}
