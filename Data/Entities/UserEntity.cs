
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(125)")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(125)")]
    public string LastName { get; set; } = null!;

    public ICollection<UserProjectsEntity> UserProjects { get; set; } = null!;
    public LoginEntity Login { get; set; } = null!;
}
