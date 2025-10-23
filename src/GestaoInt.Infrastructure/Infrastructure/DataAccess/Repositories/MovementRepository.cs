using GestaoInt.Domain.Entities;
using GestaoInt.Domain.Enums;
using GestaoInt.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GestaoInt.Infrastructure.Infrastructure.DataAccess.Repositories;

public class MovementRepository: IMovementsReadOnlyRepository, IMovementsWriteOnlyRepository, IMovementUpdateOnlyRepository
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
    async Task<Movement?> IMovementsReadOnlyRepository.GetById(User user, Guid id)
    {
        return await GetFullMovement().AsNoTracking().FirstOrDefaultAsync(movement => movement.UserId == user.Id);
    }

    async Task<Movement?> IMovementUpdateOnlyRepository.GetById(User user, Guid id)
    {
        return await GetFullMovement().FirstOrDefaultAsync(movement => movement.Id == id && movement.UserId == user.Id);
    }

    public void Update(Movement movement)
    {
        _dbContext.Movements.Update(movement);
    }

    public async Task<List<Movement>> FilterByMonth(User user, DateOnly date)
    {
        var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

        var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
        var endDate = new DateTime(year: date.Year, month: date.Month, daysInMonth, hour: 23, minute: 59, second: 59);

        return await _dbContext.Movements.AsNoTracking()
            .Where(movement => movement.UserId == user.Id && movement.Date >= startDate && movement.Date <= endDate)
            .OrderBy(movement => movement.Date).ThenBy(movement => movement.Value).ToListAsync();

    }
    private IIncludableQueryable<Movement, User> GetFullMovement()
    {
        return _dbContext.Movements.Include(movement => movement.User);
    }

    public IQueryable<Movement> GetFilterMovementsAdvanced(User user, MovementType? type, MovementCategory? category, decimal? value, DateTime? date)
    {
        var query = _dbContext.Movements.Where(movements => movements.UserId == user.Id);

        if (type != null)
        {
            query = query.Where(movement => movement.Type == type);
        }

        if (category != null)
        {
            query = query.Where(movement => movement.Category == category);
        }

        if (value != null)
        {
            query = query.Where(movement => movement.Value == value);
        }

        if (date != null)
        {
            query = query.Where(_movement => _movement.Date == date);
        }

        return query
            .OrderBy(m => m.Date)
            .ThenBy(m => m.Value);
    }
}
