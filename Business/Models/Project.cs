namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }

    public int ManagerId { get; set; }
    public Employee? Manager { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    public int ServicesId { get; set; }
    public Service? Service { get; set; }

    public decimal ServiceCost { get; set; }

}
