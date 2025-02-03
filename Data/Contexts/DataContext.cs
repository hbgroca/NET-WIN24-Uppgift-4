using Data.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    // Specify DbSet Entities
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<StatusEntity> StatusType { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }



    // Overrides
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //// In Memory cache, to increase performance
        //optionsBuilder.EnableServiceProviderCaching();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Make sure we start indexing at 100 and auto incriment by 1
        modelBuilder.Entity<ProjectEntity>()
            .Property(p => p.Id)
            .UseIdentityColumn(100, 1);

        modelBuilder.Entity<StatusEntity>()
            .HasData(
                new StatusEntity { Id = 1, StatusDescription = "Completed" },
                new StatusEntity { Id = 2, StatusDescription = "In Progress" },
                new StatusEntity { Id = 3, StatusDescription = "Not Started" }
            );

        modelBuilder.Entity<ServiceEntity>()
            .HasData(
                new ServiceEntity { Id = 1, ServiceName = "Consulting", Price = 135 },
                new ServiceEntity { Id = 2, ServiceName = "Web Development", Price = 145 },
                new ServiceEntity { Id = 3, ServiceName = "Mobile Development", Price = 145 },
                new ServiceEntity { Id = 4, ServiceName = "Database Development", Price = 145 },
                new ServiceEntity { Id = 5, ServiceName = "Backend Performance", Price = 140 },
                new ServiceEntity { Id = 6, ServiceName = "Hang out", Price = 0 }
            );
    }
}
