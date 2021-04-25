using Microsoft.EntityFrameworkCore;

namespace Micropack.Localization
{
    public class LocalizationDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
             
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Server=192.168.1.13\\mssqlserver19;Database=HSE.Customers;user ID=sa;Password=algorithm@123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LanguageMap());
        }
    }
}
