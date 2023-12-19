using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane_.Entities
{
    [Table("CalismaSaatleri")]
    public class CalismaSaati
    {
        [Key]
        public Guid CalismaSaatiId { get; set; }
        public Guid DoctorId { get; set; }

        //[ForeignKey("DoctorId")]
        public ICollection<Doctor>? Doctors { get; set; }
        public DayOfWeek CalismaGunu { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }

        

    }
}
