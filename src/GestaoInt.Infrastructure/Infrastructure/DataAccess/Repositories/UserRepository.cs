using GestaoInt.Domain.Entities;

namespace GestaoInt.Infrastructure.Infrastructure.DataAccess.Repositories;

internal class UserRepository
{
    private readonly GestaoIntDbContext _dbContext;

    public UserRepository(GestaoIntDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }
}