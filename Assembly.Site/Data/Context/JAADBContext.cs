using Assembly.Site.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Assembly.Site.Data.Context
{
    public class JAADBContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Operation> Operations { get; set; }

        public JAADBContext(DbContextOptions<JAADBContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                        .HasOne(o => o.Device)
                        .WithMany().IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
