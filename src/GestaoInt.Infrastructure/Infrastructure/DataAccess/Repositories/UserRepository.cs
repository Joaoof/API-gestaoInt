﻿using GestaoInt.Domain.Entities;
using GestaoInt.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace GestaoInt.Infrastructure.Infrastructure.DataAccess.Repositories;

internal class UserRepository: IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly GestaoIntDbContext _dbContext;

    public UserRepository(GestaoIntDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task Delete(User user)
    {
        var userToRemove = await _dbContext.Users.FindAsync(user.Id);
        _dbContext.Users.Remove(userToRemove!);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }
}