﻿using System.ComponentModel.DataAnnotations;

namespace Data.Entities;
public class StatusEntity
{
    [Key]
    public int Id { get; set; }
    public string StatusDescription { get; set; } = "Not Started";
}

