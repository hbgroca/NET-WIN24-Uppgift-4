using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(125)")]
        public string Name { get; set; } = null!;


        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        [Required]
        public int ManagerId { get; set; }
        public UserEntity Manager { get; set; } = null!;

        [Required]
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;

        [Required]
        public ProjectStatus Status { get; set; }

        public ICollection<UserProjectsEntity> UserProjects { get; set; } = null!;
    }

    public enum ProjectStatus
    {
        EnPåbörjat,
        Pågående,
        Avslutat
    }
}
