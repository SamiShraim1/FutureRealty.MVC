using FutureRealty.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FutureRealty.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AboutNumber>().HasData(
             new AboutNumber
             {
                 Id = 1,
                 HappyClients = 232,
                 Projects = 521,
                 HoursOfSupport = 1463,
                 HardWorkers = 15
             }
                );

            var roleAdminId = Guid.NewGuid().ToString();
            var roleUserId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = roleAdminId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = roleUserId, Name = "User", NormalizedName = "USER" }
            );
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@comp.com",
                NormalizedUserName = "ADMIN@COMP.COM",
                Email = "admin@comp.com",
                NormalizedEmail = "ADMIN@COMP.COM",
                EmailConfirmed = true
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");


            var User = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "User@comp.com",
                NormalizedUserName = "USER@COMP.COM",
                Email = "User@comp.com",
                NormalizedEmail = "USER@COMP.COM",
                EmailConfirmed = true
            };
            User.PasswordHash = hasher.HashPassword(User, "User123!");


            builder.Entity<ApplicationUser>().HasData(adminUser, User);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = roleAdminId, UserId = adminUser.Id },
                new IdentityUserRole<string> { RoleId = roleUserId, UserId = User.Id }

            );

        

    }

        public DbSet<Service> Services { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<OurTeam> OurTeams { get; set; }

        public DbSet<AboutNumber> AboutNumbers { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

    }
  
}

