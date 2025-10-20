using GestaoInt.Domain.Enums;

namespace GestaoInt.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } 
    public DateTime LastUpdatedAt { get; set; }
    public Product Product { get; set; }
    public string UserId { get; set; }
}
