using aspnetcore_n_tier.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_n_tier.DAL.DataContext
{
    public class AspNetCoreNTierDbContext: DbContext
    {
        public AspNetCoreNTierDbContext(DbContextOptions<AspNetCoreNTierDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Warehouse> warehouses { get; set; }
        public DbSet<Warehouseitem> warehouseitems { get; set; }
        public DbSet<Country> countries { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Role>().HasData(new Role { 
                ID= 1,
                Name = "Admin",
               
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                ID = 2,
                Name = "Management",

            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                ID = 3,
                Name = "Auditor",

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                ID = 1,
                Username = "happywarehous",
                Password = "P@ssw0rd",
                FullName = "happy warehous",
                Email = "admin@happywarehouse.com",
                IsActive = true,
                RoleId = 1,
            });
        modelBuilder.Entity<User>()
     .HasIndex(u => u.Email)
     .IsUnique();
            modelBuilder.Entity<Warehouse>()
        .HasIndex(u => u.Name)
        .IsUnique();
       modelBuilder.Entity<Warehouseitem>()
     .HasIndex(u => u.name)
     .IsUnique();
        }
    }
}
