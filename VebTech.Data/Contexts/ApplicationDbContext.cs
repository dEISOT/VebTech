using Microsoft.EntityFrameworkCore;
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
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
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
            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role{Id = new Guid("1d2a8348-203d-4135-ba65-491e134eaf68"), RoleName = "User"},
                    new Role{Id = new Guid("a639ddb4-02e8-4e48-a261-e1e46b525a95"), RoleName = "Admin"},
                    new Role{Id = new Guid("670dbe30-9559-4769-9d7a-9586a6792c43"), RoleName = "Support"},
                    new Role{Id = new Guid("a50b5ab1-dcb9-4afa-a18a-d5c2beae174e"), RoleName = "SuperAdmin"},
                });

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User{Id = new Guid("ef1a0d40-2d0e-488e-aa8d-b822d1a4296a"), Name = "User", Email ="user@gmail.com", Age = 18, PasswordHash =BCrypt.Net.BCrypt.HashPassword("User")},
                    new User{Id = new Guid("e97dfc7d-e0e1-4d4b-9d16-14c0bdaccd66"), Name = "Admin", Email ="admin@gmail.com", Age = 18, PasswordHash =BCrypt.Net.BCrypt.HashPassword("Admin")},
                    new User{Id = new Guid("cf4fa1ad-f8fc-4aaa-a9e7-b82baf8f7fb7"), Name = "SupportAndAdmin", Email ="SuperAdminAndAdmin@gmail.com", Age = 18, PasswordHash =BCrypt.Net.BCrypt.HashPassword("SupportAndAdmin")},
                    new User{Id = new Guid("d30159c4-d99e-4ee0-ae00-686c3db430e4"), Name = "SuperAdmin", Email ="SuperAdmin@gmail.com", Age = 18, PasswordHash =BCrypt.Net.BCrypt.HashPassword("SuperAdmin")},
                });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole[]
                {
                    new UserRole{UserId = new Guid("ef1a0d40-2d0e-488e-aa8d-b822d1a4296a"), RoleId =new Guid("1d2a8348-203d-4135-ba65-491e134eaf68")},
                    new UserRole{UserId = new Guid("e97dfc7d-e0e1-4d4b-9d16-14c0bdaccd66"), RoleId =new Guid("a639ddb4-02e8-4e48-a261-e1e46b525a95")},
                    new UserRole{UserId = new Guid("cf4fa1ad-f8fc-4aaa-a9e7-b82baf8f7fb7"), RoleId =new Guid("670dbe30-9559-4769-9d7a-9586a6792c43")},
                    new UserRole{UserId = new Guid("cf4fa1ad-f8fc-4aaa-a9e7-b82baf8f7fb7"), RoleId =new Guid("a639ddb4-02e8-4e48-a261-e1e46b525a95")},
                    new UserRole{UserId = new Guid("d30159c4-d99e-4ee0-ae00-686c3db430e4"), RoleId =new Guid("a50b5ab1-dcb9-4afa-a18a-d5c2beae174e")},
                });
        }

    }
}
