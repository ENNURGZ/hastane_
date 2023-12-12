using System.ComponentModel.DataAnnotations;

namespace hastane_.Models
{
    public class Hasta
    {
        [Key]
        public int HastaID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Hasta Adı ")]
        public string HastaAdi { get; set; }
        public int DoktorID { get; set; }
        public Doktor Doktor { get; set; }

    }
}
