using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane_.Entities
{
    [Table("Hastalar")]
    public class Hasta
    {
        [Key]
        public Guid HastaId { get; set; }

        //[ForeignKey("Id")]
        public Guid Id { get; set; }
        public User User { get; set; }
        public ICollection<Randevu>? Randevular { get; set; } //bir hasta birden çok randevu
    }
}
