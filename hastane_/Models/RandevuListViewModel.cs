using hastane_.Entities;
using System.ComponentModel.DataAnnotations;
namespace hastane_.Models
{
    public class RandevuListViewModel
    {
        public Guid RandevuId { get; set; }
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime RandevuGunu { get; set; }
        public TimeSpan RandevuSaati { get; set; }
    }
}
