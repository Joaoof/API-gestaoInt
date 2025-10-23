namespace GestaoInt.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public string? CompanyId { get; set; }
    public string[]? Permissions { get; set; }
    public bool IsActive { get; set; }
    public DateTime Created { get; set; }

    public Guid UserIdentifier { get; set; }
}
