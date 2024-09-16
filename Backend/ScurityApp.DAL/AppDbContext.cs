using Microsoft.EntityFrameworkCore;
using ScurityApp.DAL.Model;

namespace ScurityApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<SecurityObject> SecurityObjects { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        public DbSet<Shift> Shifts{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Worker" },
                new Role { Id = 2, Name = "Coordinator" },
                new Role { Id = 3, Name = "Admin" }
            );

        }
    }
}
