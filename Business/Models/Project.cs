namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public int ManagerId { get; set; }
    public string? ManagerName { get; set; }
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
}
