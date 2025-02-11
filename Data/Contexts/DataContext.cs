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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Start indexing at 100 and auto incriment by 1
        modelBuilder.Entity<ProjectEntity>()
            .Property(p => p.Id)
            .UseIdentityColumn(100, 1);
        modelBuilder.Entity<EmployeeEntity>()
            .Property(p => p.Id)
            .UseIdentityColumn(100, 1);
        modelBuilder.Entity<CustomerEntity>()
            .Property(p => p.Id)
            .UseIdentityColumn(100, 1);
        modelBuilder.Entity<ServiceEntity>()
            .Property(p => p.Id)
            .UseIdentityColumn(100, 1);

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
                new CustomerEntity { Id = 1, CompanyNr="556501-1234", CompanyName="Töm & Glöm AB", FirstName = "Robban", LastName = "Carlsson", Email = "nustrulardetigen@helvetes.net", PhoneNumber = "555123456" },
                new CustomerEntity { Id = 2, FirstName = "Sara", LastName = "Syntax", Email = "sara.syntax@domain.net", PhoneNumber = "555654321" },
                new CustomerEntity { Id = 3, FirstName = "Markus", LastName = "Nilsson", Email = "mackan.nilsson@domain.net", PhoneNumber = "555123456" },
                new CustomerEntity { Id = 4, FirstName = "Henrik", LastName = "Rosengren", Email = "henke@domain.net", PhoneNumber = "555123456" }
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
        modelBuilder.Entity<ProjectEntity>()
            .HasData(
                new ProjectEntity 
                {
                    Id = 1,
                    ProjectName = "Build database 4 client", 
                    ServiceCost = 6500,
                    StartDate = new DateOnly(2025, 2, 1),
                    EndDate = new DateOnly(2025, 4, 01),
                    EmployeeId = 1,
                    CustomerId = 1,
                    StatusId = 2,
                    ServiceId = 4
                },
                new ProjectEntity
                {
                    Id = 2,
                    ProjectName = "Hang out with Robban",
                    ServiceCost = 0,
                    StartDate = new DateOnly(2024, 08, 26),
                    EndDate = new DateOnly(2026, 05, 29),
                    EmployeeId = 1,
                    CustomerId = 4,
                    StatusId = 2,
                    ServiceId = 2
                },
                new ProjectEntity
                {
                    Id = 3,
                    ProjectName = "Build TodoApp",
                    ServiceCost = 9000,
                    StartDate = new DateOnly(2025, 04, 01),
                    EndDate = new DateOnly(2025, 08, 31),
                    EmployeeId = 3,
                    CustomerId = 2,
                    StatusId = 3,
                    ServiceId = 6
                },
                new ProjectEntity
                {
                    Id = 4,
                    ProjectName = "Update business webpage",
                    ServiceCost = 4400,
                    StartDate = new DateOnly(2024, 12, 1),
                    EndDate = new DateOnly(2025, 01, 31),
                    EmployeeId = 2,
                    CustomerId = 2,
                    StatusId = 1,
                    ServiceId = 2
                },
                new ProjectEntity
                {
                    Id = 5,
                    ProjectName = "Optimise services",
                    ServiceCost = 3790,
                    StartDate = new DateOnly(2024, 12, 1),
                    EndDate = new DateOnly(2025, 01, 31),
                    EmployeeId = 3,
                    CustomerId = 3,
                    StatusId = 1,
                    ServiceId = 4
                }
            );
    }
}
