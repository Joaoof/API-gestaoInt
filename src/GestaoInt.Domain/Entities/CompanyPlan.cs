namespace GestaoInt.Domain.Entities;

public class CompanyPlan
{
    public Guid Id { get; set; }
    public string CompanyId { get; set; }
    public string PlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
}
