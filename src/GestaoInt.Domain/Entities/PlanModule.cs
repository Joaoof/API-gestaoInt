namespace GestaoInt.Domain.Entities;

public class PlanModule
{
    public Guid Id { get; set; }
    public string PlanId { get; set; }
    public string ModuleId { get; set; }
    public bool IsActive { get; set; }
    public string[] Permissions { get; set; }
}
