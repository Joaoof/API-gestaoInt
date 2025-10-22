using AutoMapper;
using GestaoInt.Communication.Request;
using GestaoInt.Communication.Responses;
using GestaoInt.Domain.Entities;
using GestaoInt.Domain.Repositories;
using GestaoInt.Domain.Repositories.Interfaces;
using GestaoInt.Exception.ExceptionsBase;

namespace GestaoInt.Application.UseCase.Movements.Register;

public class RegisterMovementUseCase: IRegisterMovementUseCase
{
    private readonly IMovementsWriteOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterMovementUseCase(IMovementsWriteOnlyRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisterdMovementJson> Execute(RequestMovementJson request)
    {
        Validate(request);

        var movement = _mapper.Map<Movement>(request);

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
