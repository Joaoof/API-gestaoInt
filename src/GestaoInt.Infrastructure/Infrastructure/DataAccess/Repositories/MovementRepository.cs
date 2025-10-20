using GestaoInt.Domain.Entities;
using GestaoInt.Domain.Repositories.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoInt.Infrastructure.Infrastructure.DataAccess.Repositories;

public class MovementRepository: IMovementsReadOnlyRepository
{
    private readonly GestaoIntDbContext _dbContext;

    public MovementRepository(GestaoIntDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(Movement movement)
    {
        await _dbContext.Movements.AddAsync(movement);
    }

    public async Task Delete(Guid id)
    {
        var result = await _dbContext.Movements.FindAsync(id);

        _dbContext.Movements.Remove(result!);
    }
   
    public async Task<List<Movement>> GetAll(User user)
    {
        return await _dbContext.Movements.AsNoTracking().Where(movement => movement.UserId == user.Id).ToListAsync();
    }
}
