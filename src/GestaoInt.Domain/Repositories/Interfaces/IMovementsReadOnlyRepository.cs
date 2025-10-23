using GestaoInt.Domain.Entities;

namespace GestaoInt.Domain.Repositories.Interfaces;

public interface IMovementsReadOnlyRepository
{
    Task<Movement?> GetById(User user, Guid id);
}
