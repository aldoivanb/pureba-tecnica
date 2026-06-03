using Microsoft.EntityFrameworkCore;
using testdevbackjr.Models;

namespace testdevbackjr.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .ToTable("ccUsers")   
                .HasKey(u => u.User_id);

            modelBuilder.Entity<Login>()
                .ToTable("ccloglogin") 
                .HasKey(l => l.Id);


            modelBuilder.Entity<Area>()
                .ToTable("ccRIACat_Areas")
                .HasKey(a => a.IDArea);

            modelBuilder.Entity<User>()
       .HasOne(u => u.Area)
       .WithMany(a => a.Users)
       .HasForeignKey(u => u.IDArea);
        }
    }
}