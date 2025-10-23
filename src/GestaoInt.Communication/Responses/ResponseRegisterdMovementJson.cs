using GestaoInt.Domain.Enums;

namespace GestaoInt.Communication.Responses;

public class ResponseRegisterdMovementJson
{
    public MovementType Type { get; set; }
    public MovementCategory Category { get; set; }
    public required string Description { get; set; }
    public decimal Value { get; set; }
}
