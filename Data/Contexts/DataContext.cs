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
        optionsBuilder.EnableServiceProviderCaching();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Make sure we start indexing at 100 and auto incriment by 1
        modelBuilder.Entity<ProjectEntity>()
            .Property(p => p.Id)
            .UseIdentityColumn(100, 1);
    }
}
