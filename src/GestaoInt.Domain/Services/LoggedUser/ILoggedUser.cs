using GestaoInt.Domain.Entities;

namespace GestaoInt.Domain.Services.LoggedUser;

public interface ILoggedUser
{
    Task<User> Get();
}
