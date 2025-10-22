namespace GestaoInt.Domain.Entities;

public class Inventory
{
    public Guid Id { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public int MinStock { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
