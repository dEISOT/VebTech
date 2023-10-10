using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using VebTech.Data.Entities;

namespace VebTech.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Set PKs
            modelBuilder
              .Entity<User>()
              .HasKey(u => u.Id);

            modelBuilder
              .Entity<Role>()
              .HasKey(u => u.Id);

            modelBuilder
                .Entity<UserRole>()
                .HasKey(cu => new { cu.UserId, cu.RoleId });

            modelBuilder
                .Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            //Relation between Users and Roles (many to many with 3d table UserRole)
            modelBuilder.Entity<UserRole>()
               .HasOne<User>(ur => ur.User)
               .WithMany(u => u.UserRoles)
               .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne<Role>(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            //TODO : Add Data
        }

    }
}
