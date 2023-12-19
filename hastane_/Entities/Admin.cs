using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane_.Entities
{
    [Table("Adminler")]
    public class Admin
    {
        [Key]
        public Guid AdminId { get; set; }

        //[ForeignKey("Id")]
        public Guid Id { get; set; }
        public User User { get; set; }
    }
}
