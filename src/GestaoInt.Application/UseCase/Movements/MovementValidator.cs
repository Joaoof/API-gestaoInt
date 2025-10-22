using FluentValidation;
using GestaoInt.Communication.Request;
using GestaoInt.Domain.Entities;
using GestaoInt.Exception;

namespace GestaoInt.Application.UseCase.Movements
{
    public class MovementValidator: AbstractValidator<RequestMovementJson>
    {
        public MovementValidator()
        {
            RuleFor(movement => movement.Type).IsInEnum().Must(m => Enum.IsDefined(typeof(Type), m)).WithMessage(ResourceErrorMessages.TYPE_INVALID);
            RuleFor(movement => movement.Category).IsInEnum().Must(m => Enum.IsDefined(typeof(Category), m)).WithMessage(ResourceErrorMessages.CATEGORY_TYPE_INVALID);
            RuleFor(movement => movement.Value)
                .PrecisionScale(2, 5, ignoreTrailingZeros: true).WithMessage(ResourceErrorMessages.VALUE_INVALID_PRECISION_SCALE)
                .NotEmpty().WithMessage(ResourceErrorMessages.VALUE_NOT_EMPTY)
                .NotNull().WithMessage(ResourceErrorMessages.VALUE_NOT_NULL);
            RuleFor(movement => movement.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.MOVEMENT_CANNOT_FOR_THE_FUTURE);
        }
    }
}
