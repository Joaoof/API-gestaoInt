namespace GestaoInt.Domain.Entities;

public class Module
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Module_Key { get; set; }
    public string Description { get; set; }
    public PlanModule PlanModule { get; set; }
}
