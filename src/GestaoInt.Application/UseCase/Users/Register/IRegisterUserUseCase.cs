using GestaoInt.Communication.Request;
using GestaoInt.Communication.Responses;

namespace GestaoInt.Application.UseCase.Users.Register;

public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestUserJson request);
}
