using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;
public class StatusEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string StatusDescription { get; set; } = "Not Started";
}

