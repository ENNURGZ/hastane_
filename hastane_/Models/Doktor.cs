using System.ComponentModel.DataAnnotations;

namespace hastane_.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Doktor Adı ")]
        public string DoktorAd { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Doktor Soyadı ")]
        public string DoktorSoyad { get; set; }
        public ICollection<Hasta> Hastalar { get; set; }
        
    }
}
