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
        public string ProjectName { get; set; } = null!;
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public int ManagerId { get; set; }
        public EmployeeEntity Manager { get; set; } = null!;

        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; } = null!;

        public int StatusId { get; set; }
        public StatusTypeEntity Status { get; set; } = null!;

        public ICollection<ServiceEntity> Services { get; set; } = new List<ServiceEntity>();
    }
}
