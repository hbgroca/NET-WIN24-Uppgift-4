using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;
public class EmployeeEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(45)")]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "nvarchar(45)")]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "nvarchar(125)")]
    public string Email { get; set; } = null!;

    [Column(TypeName = "nvarchar(25)")]
    public string? Phone { get; set; }

    public IEnumerable<ProjectEntity>? Projects { get; set; }
}
