using System.ComponentModel.DataAnnotations;
namespace hastane_.Models
{
    public class DoctorListViewModel
    {       
            public Guid DoctorId { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string RePassword { get; set; }
            public int PoliklinikId { get; set; }
            public bool Locked { get; set; } = false;
            public DayOfWeek CalismaGunu { get; set; }
            public TimeSpan BaslangicSaati { get; set; }
            public TimeSpan BitisSaati { get; set; }
    }
    public class DoctorDuzenleViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public int PoliklinikId { get; set; }
        public bool Locked { get; set; } = false;
        public DayOfWeek CalismaGunu { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
    }

}
