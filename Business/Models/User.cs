using Data.Entities;

namespace Business.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public IEnumerable<Project>? UserProjects { get; set; } = [];
}
