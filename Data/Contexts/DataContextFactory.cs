using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HBGROCA\\Desktop\\Github\\NET-WIN24-Uppgift-4\\Data\\Databases\\LocalDB.mdf;Integrated Security=True;Connect Timeout=30");

        return new DataContext(optionsBuilder.Options);
    }
}