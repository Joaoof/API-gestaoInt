using AutoMapper;
using FluentValidation.Results;
using GestaoInt.Communication.Request;
using GestaoInt.Communication.Responses;
using GestaoInt.Domain.Repositories;
using GestaoInt.Domain.Repositories.User;
using GestaoInt.Domain.Security.Cryptography;
using GestaoInt.Domain.Security.Tokens;
using GestaoInt.Exception;
using GestaoInt.Exception.ExceptionsBase;

namespace GestaoInt.Application.UseCase.Users.Register;

public class RegisterUserUseCase: IRegisterUserUseCase
{
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public RegisterUserUseCase(IUserWriteOnlyRepository userWriteOnlyRepository, IMapper mapper, IUnitOfWork unitOfWork, IPasswordEncripter passwordEncripter, IAccessTokenGenerator accessTokenGenerator, IUserReadOnlyRepository userReadOnlyRepository)
    {
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _userReadOnlyRepository = userReadOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _passwordEncripter = passwordEncripter;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestUserJson request)
    {
        await Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);
        user.Password = _passwordEncripter.Encrypt(request.Password);
        user.UserIdentifier = Guid.NewGuid();
        user.Role = "ADMIN";
        user.Created = DateTime.UtcNow;

        await _userWriteOnlyRepository.Add(user);

        await _unitOfWork.Commit();

        return new ResponseRegisteredUserJson
        {
            Name = user.Name!,
            Token = _accessTokenGenerator.Generate(user)
        };
    }

    private async Task Validate(RequestUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        var emailExists = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

        if(emailExists)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
        }

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
