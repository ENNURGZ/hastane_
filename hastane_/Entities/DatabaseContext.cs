using Microsoft.EntityFrameworkCore;

namespace hastane_.Entities
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options): base(options) 
        {
        }
        public DbSet<User> Users { get; set; }

    }
}