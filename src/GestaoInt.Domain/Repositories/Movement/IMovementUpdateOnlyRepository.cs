using GestaoInt.Domain.Entities;

namespace GestaoInt.Domain.Repositories.Movement;

public interface IMovementUpdateOnlyRepository
{
    Task<Entities.Movement?> GetById(Entities.User user, Guid id);
}
