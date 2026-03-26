using Microsoft.EntityFrameworkCore;
using RandomUserApi.Models;

namespace RandomUserApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Login> login { get; set; }
        public DbSet<Location> location { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Login)
                .WithMany() 
                .HasForeignKey(u => u.LoginId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Location)
                .WithMany()
                .HasForeignKey(u => u.LocationId);
        }
    }

}
