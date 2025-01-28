using Business.Models;

namespace Business.Dtos;

public class ProjectRegistrationForm
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    public int ManagerId { get; set; }
    public int CustomerId { get; set; }

    public int ServiceId { get; set; }

    public decimal ServiceCost { get; set; }

    public int StatusId { get; set; }
}
