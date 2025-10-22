using GestaoInt.Domain.Repositories;

namespace GestaoInt.Infrastructure.Infrastructure.DataAccess;

public class UnitOfWork: IUnitOfWork
{
    private readonly GestaoIntDbContext _dbContext;

    public UnitOfWork(GestaoIntDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
