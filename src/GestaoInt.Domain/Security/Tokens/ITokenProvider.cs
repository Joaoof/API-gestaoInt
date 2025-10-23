namespace GestaoInt.Domain.Security.Tokens;

public interface ITokenProvider
{
    string TokenOnRequest();
}
