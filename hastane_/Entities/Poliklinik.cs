using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane_.Entities
{
    [Table("Poliklinikler")]
    public class Poliklinik
    {
        [Key]
        public int PoliklinikId { get; set; }

        [Required]
        [StringLength(100)]
        public string PoliklinikAdi { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}