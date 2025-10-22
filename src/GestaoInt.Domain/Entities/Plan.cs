namespace GestaoInt.Domain.Entities;

public class Plan
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool IsActived { get; set; }
    public Module Module { get; set; }
}
