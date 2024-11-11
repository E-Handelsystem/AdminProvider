using System.ComponentModel.DataAnnotations;

namespace AdminProvider.Domain.Models;

public class ProductRequest 
{
    [Required]
    public string Name { get; set; } = null!; //Obligatorisk
    public string? Description { get; set; } //Valbart

    [Required]
    public string Price { get; set; } = null!; //Obligatorisk
    public object? Picture { get; set; } //Valbart
}

