namespace GestaoInt.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
