using Microsoft.EntityFrameworkCore;


namespace hastane_.Models
{
    public class HastaneContext : DbContext
    {
        public DbSet<Hasta> Hastalar {  get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=hastanerandevu;Trusted_Connection=True;");
        }
    }
}
