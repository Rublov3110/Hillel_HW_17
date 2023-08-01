using Microsoft.EntityFrameworkCore;

namespace Hillel_HW_12
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MyFamiliar> MyFamiliars { get; set; }
        public DbSet<Status> Status { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
         => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MyFamiliarConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
        }
    }
}
