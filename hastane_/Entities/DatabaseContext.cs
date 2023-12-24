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

            modelBuilder.Entity<Admin>().HasData(
    new Admin
    {
        AdminId = Guid.NewGuid(),
        Name = "YourName",
        Surname = "YourSurname",
        Username = "b211210004@sakarya.edu.tr",
        Password = "sau",
        Locked = false,
        Role = "admin"
    }
);

        }


    }  
}