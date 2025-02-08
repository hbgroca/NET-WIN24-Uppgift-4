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
        // Start indexing at 100 and auto incriment by 1
        modelBuilder.Entity<ProjectEntity>()
            .Property(p => p.Id)
            .UseIdentityColumn(100, 1);


        // No action so we can delete entity without deleting the project.
        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Customer)
            .WithMany()
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Employee)
            .WithMany()
            .HasForeignKey(p => p.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Service)
            .WithMany()
            .HasForeignKey(p => p.ServiceId)
            .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<StatusEntity>()
            .HasData(
                new StatusEntity { Id = 1, StatusDescription = "Completed" },
                new StatusEntity { Id = 2, StatusDescription = "In Progress" },
                new StatusEntity { Id = 3, StatusDescription = "Not Started" }
            );

        modelBuilder.Entity<EmployeeEntity>()
            .HasData(
                new EmployeeEntity { Id = 1, FirstName = "Klabbe", LastName="Röv", Email="nustrulardetigen@helvetes.net", Phone= "0701234567" },
                new EmployeeEntity { Id = 2, FirstName = "Hasse", LastName="Kompilator", Email= "hasse.kopilator@domain.net", Phone= "0700765321" },
                new EmployeeEntity { Id = 3, FirstName = "Nils", LastName="Visman", Email= "nisse@domain.net", Phone= "0700123456" }
            );

        modelBuilder.Entity<CustomerEntity>()
            .HasData(
                new CustomerEntity { Id = 1, CompanyNr="556501-1234", CompanyName="Töm & Glöm AB", FirstName = "Robban", LastName = "Carlsson", Email = "nustrulardetigen@helvetes.net", PhoneNumber = "555-123456" },
                new CustomerEntity { Id = 2, FirstName = "Sara", LastName = "Syntax", Email = "sara.syntax@domain.net", PhoneNumber = "555-654321" },
                new CustomerEntity { Id = 3, FirstName = "Markus", LastName = "Nilsson", Email = "mackan.nilsson@domain.net", PhoneNumber = "555-123456" },
                new CustomerEntity { Id = 4, FirstName = "Henrik", LastName = "Rosengren", Email = "henke@domain.net", PhoneNumber = "555-123456" }
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
