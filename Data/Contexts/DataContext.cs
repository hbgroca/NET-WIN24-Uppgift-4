using Data.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    // Skapa migration via PackageManager Console
    // Add-Migration "User Table Added"
    // Remove-migration för att ångra

    // Update-Database för att köra uppdatering.


    // Skapa tabell enligt UserEntity
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<StatusTypeEntity> StatusType { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }



    // Overrides
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //// URL Till DB bör sättas i presentationslager inte i DB lager.
        //optionsBuilder.UseSqlServer("URL TO DB");

        //// Aktivera lazyloading, kräver nugget paket.
        //optionsBuilder.UseLazyLoadingProxies();

        //// För loggning av känslig information (endast för develop)
        //optionsBuilder.EnableSensitiveDataLogging();
        //// Loggning
        //optionsBuilder.LogTo(Console.WriteLine);

        //// In Memory cache, förbättrar prestandan
        //optionsBuilder.EnableServiceProviderCaching();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Om man vill köra unik epost. Går även att göra i entity.
        //modelBuilder.Entity<UserEntity>()
        //    .HasIndex(x => x.Email)
        //    .IsUnique();

        //modelBuilder.Entity<ProjectEntity>()
        //    .HasOne(x => x.Manager)
        //    .WithMany(x => x.Pr)
        //    .HasForeignKey(x => x.ManagerId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}
