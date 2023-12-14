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

    }
}