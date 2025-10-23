using GestaoInt.Domain.Entities;
using GestaoInt.Domain.Security.Tokens;
using GestaoInt.Domain.Services.LoggedUser;
using GestaoInt.Infrastructure.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GestaoInt.Infrastructure.Services.LoggedUser;

internal class LoggedUser: ILoggedUser
{
    private readonly GestaoIntDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;

    public LoggedUser(GestaoIntDbContext dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }
    public async Task<User> Get()
    {
        string token = _tokenProvider.TokenOnRequest();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return await _dbContext.Users.AsNoTracking().FirstAsync(user => user.UserIdentifier == Guid.Parse(identifier));
    }
}
