using hastane_.Entities;
using Microsoft.EntityFrameworkCore;

namespace hastane_.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Admin> Adminler { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.User)
                .WithMany(u => u.Randevular)
                .HasForeignKey(r => r.Id); // User ile ilişkilendirilen foreign key

            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Doctor)
                .WithMany(d => d.Randevular)
                .HasForeignKey(r => r.DoctorId); // Doctor ile ilişkilendirilen foreign key

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Poliklinik)
                .WithMany(p => p.Doctors)
                .HasForeignKey(d => d.PoliklinikId);

            modelBuilder.Entity<Poliklinik>().HasData(
            new Poliklinik { PoliklinikId = 1, PoliklinikAdi = "Kadın-Doğum" },
            new Poliklinik { PoliklinikId = 2, PoliklinikAdi = "Dahiliye" },
            new Poliklinik { PoliklinikId = 3, PoliklinikAdi = "Cildiye" },
            new Poliklinik { PoliklinikId = 4, PoliklinikAdi = "Nöroloji" },
            new Poliklinik { PoliklinikId = 5, PoliklinikAdi = "Pediatri" },
            new Poliklinik { PoliklinikId = 6, PoliklinikAdi = "Kulak-burun-boğaz" },
            new Poliklinik { PoliklinikId = 7, PoliklinikAdi = "Göz-hastalıkları" },
            new Poliklinik { PoliklinikId = 8, PoliklinikAdi = "Psikiatri" }
        );

            modelBuilder.Entity<Admin>().HasData(
    new Admin
    {
        AdminId = Guid.NewGuid(),
        Name = "Ennur",
        Surname = "Gürbüz",
        Username = "b211210060@sakarya.edu.tr",
        Password = "97CE14A55420C6F332C0A16644B1A47C",
        Locked = false,
        Role = "admin"
    }
);

        }


    }
}