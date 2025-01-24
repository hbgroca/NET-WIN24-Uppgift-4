using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    public class CustomerEntity
    {
        [Key] public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")] public string OrganisationNumber { get; set; }
        [Column(TypeName = "nvarchar(50)")] public string CompanyName { get; set; }
        [Required][Column(TypeName = "nvarchar(50)")] public string FirstName { get; set; } = null!;
        [Required][Column(TypeName = "nvarchar(50)")] public string LastName { get; set; } = null!;
        [Required][Column(TypeName = "varchar(200)")] public string? Email { get; set; } = null!;
        [Required][Column(TypeName = "nvarchar(20)")] public string? PhoneNumber { get; set; }

        public ICollection<ProjectEntity> Projects { get; set; } = null!;
    }
}