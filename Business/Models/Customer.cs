namespace Business.Models;

internal class Customer
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
}
