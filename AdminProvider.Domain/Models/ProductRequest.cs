namespace AdminProvider.Domain.Models;

public class ProductRequest 
{
    public string Name { get; set; } = null!; //Obligatorisk
    public string? Description { get; set; } //Valbart
    public string Price { get; set; } = null!; //Obligatorisk
    public object? Picture { get; set; } //Valbart
}

