using GestaoInt.Domain.Security.Tokens;

namespace GestaoInt.Api.Tokens;

public class HttpContextTokenValue : ITokenProvider
{
    private readonly IHttpContextAccessor _contextAccessor;
    public HttpContextTokenValue(IHttpContextAccessor httpContextAccessor)
    {
        _contextAccessor = httpContextAccessor;
    }

    public string TokenOnRequest()
    {
        var authorizationHeader = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authorizationHeader["Bearer ".Length..].Trim();
    }

}
