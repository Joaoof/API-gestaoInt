using AutoMapper;
using GestaoInt.Communication.Request;
using GestaoInt.Communication.Responses;
using GestaoInt.Domain.Entities;
using GestaoInt.Domain.Repositories;
using GestaoInt.Domain.Repositories.Interfaces;
using GestaoInt.Domain.Services.LoggedUser;
using GestaoInt.Exception.ExceptionsBase;

namespace GestaoInt.Application.UseCase.Movements.Register;

public class RegisterMovementUseCase: IRegisterMovementUseCase
{
    private readonly IMovementsWriteOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _loggedUser;
    public RegisterMovementUseCase(IMovementsWriteOnlyRepository repository, IMapper mapper, IUnitOfWork unitOfWork, ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseRegisterdMovementJson> Execute(RequestMovementJson request)
    {
        Validate(request);

        var loggedUser = await _loggedUser.Get();

        var movement = _mapper.Map<Movement>(request);
        movement.UserId = loggedUser.Id;

        await _repository.Add(movement);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisterdMovementJson>(movement);

    }

    private void Validate(RequestMovementJson request)
    {
        var validator = new MovementValidator();

        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
