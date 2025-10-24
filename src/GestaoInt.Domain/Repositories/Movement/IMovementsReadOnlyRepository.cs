namespace GestaoInt.Domain.Repositories.Movement;

public interface IMovementsReadOnlyRepository
{
    Task<Entities.Movement?> GetById(Entities.User user, Guid id);
}
