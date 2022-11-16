using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SanclerAPI.Models;


namespace SanclerAPI.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Assessments> Assessments { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
              .Property(p => p.Title)
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
             .Property(p => p.Descriptions)
               .HasMaxLength(300);

            modelBuilder.Entity<Product>()
             .Property(p => p.SKU)
               .HasMaxLength(15);

            modelBuilder.Entity<Product>()
           .Property(p => p.Price)
             .HasPrecision(10, 2);

            modelBuilder.Entity<Comments>()
            .Property(p => p.Comment)
              .HasMaxLength(150);


            IdentityUser admin = new IdentityUser
            {
                UserName = "admin@sancler.com",
                NormalizedUserName = "ADMIN@SANCLER.COM",
                Email = "admin@sancler.com",
                NormalizedEmail = "ADMIN@SANCLER.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = "adminIDsanclerAPI00213554856Pqwus"
                
            };

            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = hasher.HashPassword(admin,  "Admin@123");
            modelBuilder.Entity<IdentityUser>().HasData(admin);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole {Id = "adminIDsanclerAPI00213554856Pqwus", Name = "admin", NormalizedName = "ADMIN"}
            );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole {Id = "regular123aosdm123bJASNd", Name = "regular", NormalizedName = "REGULAR"}
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> {RoleId = "adminIDsanclerAPI00213554856Pqwus", UserId = admin.Id}
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}