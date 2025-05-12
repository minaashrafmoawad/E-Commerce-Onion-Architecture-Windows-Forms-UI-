using Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=.;DataBase=E-Commerce4;Trusted_Connection=True;TrustServerCertificate=True")
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        //private void SeedData(ModelBuilder modelBuilder)
        //{
        //    // You can add initial admin user, categories, etc. here
        //    // Example:
        //    modelBuilder.Entity<User>().HasData(
        //        new User
        //        {
        //             UserID = 1,
        //            FirstName = "Admin",
        //            LastName = "User",
        //            Username = "admin",
        //            Email = "admin@example.com",
        //            Password = BCrypt.Net.BCrypt.HashPassword("1234"),
        //            Role = UserRole.Admin,
        //            IsActive = true,


        //        }
        //    );
    //} 
    }
}
