namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int ManagerId { get; set; }
    public User? Manager { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public string Status { get; set; } = "Avslutat";
    public IEnumerable<Service> Services { get; set; } = [];

}
