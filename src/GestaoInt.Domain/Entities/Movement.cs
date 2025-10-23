using GestaoInt.Domain.Enums;

namespace GestaoInt.Domain.Entities;

public class Movement
{
    public Guid Id { get; set; }
    public MovementType Type { get; set; }
    public MovementCategory Category { get; set; } 
    public required string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime Date {  get; set; } 
    public Guid UserId { get; set; }
    public required User User { get; set; }

}
