﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;
public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(125)")]
    public string ProjectName { get; set; } = null!;

    [Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateOnly StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateOnly? EndDate { get; set; }

    public int? EmployeeId { get; set; }
    public EmployeeEntity? Employee { get; set; }

    public int? CustomerId { get; set; }
    public CustomerEntity? Customer { get; set; }

    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;

    public int? ServiceId { get; set; }
    public ServiceEntity? Service { get; set; }

    public decimal ServiceCost { get; set; }
}
