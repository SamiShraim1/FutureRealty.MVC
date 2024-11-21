using FutureRealty.DAL.Data;
using FutureRealty.PL.Core.Mapping;
using FutureRealty.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FutureRealty.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Identity Configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

            // MVC and AutoMapper
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // HSTS for production environments
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Ensure Authentication middleware is added
            app.UseAuthorization();

            // Middleware ·· Õﬁﬁ „‰  ”ÃÌ· «·œŒÊ· Ê≈⁄«œ… «· ÊÃÌÂ
            app.Use(async (context, next) =>
            {
                var isAuthenticated = context.User.Identity?.IsAuthenticated ?? false;
                var currentPath = context.Request.Path;

                // «” À‰«¡ AccountController »«·ﬂ«„·
                if (!isAuthenticated &&
                    !currentPath.StartsWithSegments("/Account"))
                {
                    context.Response.Redirect("/Account/Login");
                    return;
                }

                await next();
            });

            // Define area routes first, then default route
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
