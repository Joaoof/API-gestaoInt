using FluentValidation;
using GestaoInt.Communication.Request;
using GestaoInt.Exception;

namespace GestaoInt.Application.UseCase.Users.Register;

public class RegisterUserValidator: AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_EMPTY).EmailAddress().When(user => string.IsNullOrWhiteSpace(user.Email) == false).WithMessage(ResourceErrorMessages.EMAIL_INVALID);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestUserJson>());

    }
}
