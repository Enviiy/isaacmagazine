using isaacmagazine.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace isaacmagazine.Domain 
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        // Наши таблицы БД
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string adminName = "admin";
            string roleAdminId = "{50E3664F-A4B5-4D25-9DE8-ABBD1D99501E}"; 
            string userAdminId = "{6166694F-5F3B-4737-8DDA-6025E9D57B41}"; 

            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = roleAdminId,
                Name = adminName,
                NormalizedName = adminName.ToUpper(),
            });


            builder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
                Id = userAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = "admin@gameStore.com",
                NormalizedEmail = "admin@gameStore.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(), "admin"),
                SecurityStamp = string.Empty,
                PhoneNumberConfirmed = true
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = roleAdminId,
                UserId = userAdminId,
            });
        }
    }
}