using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VolunteerApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Volunteer>().HasData(
                new Volunteer() { ID = 1, FirstName = "Ivan", LastName = "Valdes", Status = "Approved" },
                new Volunteer() { ID = 2, FirstName = "Barb", LastName = "Valdes", Status = "Pending Approval" },
                new Volunteer() { ID = 3, FirstName = "Bert", LastName = "Valdes", Status = "Disapproved" },
                new Volunteer() { ID = 4, FirstName = "Cook", LastName = "Valdes", Status = "Inactive" }

                );
        }
        public DbSet<Volunteer> Volunteers { get; set; }
    }
}