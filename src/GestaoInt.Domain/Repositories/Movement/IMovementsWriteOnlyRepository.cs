using GestaoInt.Domain.Entities;

namespace GestaoInt.Domain.Repositories.Interfaces;

public interface IMovementsWriteOnlyRepository
{
    Task Add(Entities.Movement movement);
    Task Delete(Guid id);

}
