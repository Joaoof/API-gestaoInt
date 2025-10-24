using GestaoInt.Communication.Request;
using GestaoInt.Communication.Responses;

namespace GestaoInt.Application.UseCase.Login.DoLogin;

internal interface IDoLoginUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}
