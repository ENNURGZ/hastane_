using Microsoft.EntityFrameworkCore;

namespace hastane_.Entities
{
    public class DatabaseContext:DbContext
    {
        {
        }

        public DbSet<User> Users { get; set; }
    }
}