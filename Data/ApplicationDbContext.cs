using Code1stUsersRoles.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Code1stUsersRoles.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser, CustomRole, string>
    {
        public DbSet<Article> Articles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedUsersRoles seedUsersRoles = new();
            builder.Entity<CustomRole>().HasData(seedUsersRoles.Roles);
            builder.Entity<CustomUser>().HasData(seedUsersRoles.Users);
            builder.Entity<IdentityUserRole<string>>().HasData(seedUsersRoles.UserRoles);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}