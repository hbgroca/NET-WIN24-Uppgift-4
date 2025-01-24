namespace Business.Dtos;

public class ProjectRegistrationForm
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public int ManagerId { get; set; }
    public int CustomerId { get; set; }
}
