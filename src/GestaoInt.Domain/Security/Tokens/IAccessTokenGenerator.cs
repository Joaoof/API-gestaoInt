using GestaoInt.Domain.Entities;

namespace GestaoInt.Domain.Security.Tokens;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}
