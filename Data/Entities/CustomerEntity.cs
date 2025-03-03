﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;
public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(16)")]
    public string? CompanyNr { get; set; }

    [Column(TypeName = "nvarchar(125)")]
    public string? CompanyName { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(45)")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(45)")]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "nvarchar(25)")]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "nvarchar(125)")]
    public string? Email { get; set; }

    public IEnumerable<ProjectEntity>? Projects { get; set; }
}

