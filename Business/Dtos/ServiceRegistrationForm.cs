namespace Business.Dtos;

public class ServiceRegistrationForm
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }

    public int ProjectId { get; set; }
}
