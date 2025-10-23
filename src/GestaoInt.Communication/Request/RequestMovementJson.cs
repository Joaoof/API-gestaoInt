using GestaoInt.Domain.Enums;

namespace GestaoInt.Communication.Request;

public class RequestMovementJson
{
    public MovementType Type { get; set; }
    public MovementCategory Category { get; set; }
    public required string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
}
