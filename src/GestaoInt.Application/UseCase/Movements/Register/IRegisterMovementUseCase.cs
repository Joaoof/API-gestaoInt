using GestaoInt.Communication.Request;
using GestaoInt.Communication.Responses;

namespace GestaoInt.Application.UseCase.Movements.Register;

public interface IRegisterMovementUseCase
{
    Task<ResponseRegisterdMovementJson> Execute(RequestMovementJson request);
}
