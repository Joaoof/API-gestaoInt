using FluentValidation;
using GestaoInt.Communication.Request;
using GestaoInt.Domain.Enums;
using GestaoInt.Exception;

namespace GestaoInt.Application.UseCase.Movements
{
    public class MovementValidator: AbstractValidator<RequestMovementJson>
    {
        public MovementValidator()
        {
            RuleFor(movement => movement.Type).IsInEnum().Must(m => Enum.IsDefined(typeof(MovementType), m)).WithMessage(ResourceErrorMessages.TYPE_INVALID);
            RuleFor(movement => movement.Category).IsInEnum().Must(m => Enum.IsDefined(typeof(MovementCategory), m)).WithMessage(ResourceErrorMessages.CATEGORY_TYPE_INVALID);
            RuleFor(movement => movement.Value)
                .PrecisionScale(5, 2,ignoreTrailingZeros: true).WithMessage(ResourceErrorMessages.VALUE_INVALID_PRECISION_SCALE)
                .NotEmpty().WithMessage(ResourceErrorMessages.VALUE_NOT_EMPTY)
                .NotNull().WithMessage(ResourceErrorMessages.VALUE_NOT_NULL);
            RuleFor(movement => movement.Description).NotEmpty().WithMessage(ResourceErrorMessages.DESCRIPTION_NOT_EMPTY).NotNull().WithMessage(ResourceErrorMessages.DESCRIPTION_NOT_NULL);
            RuleFor(movement => movement.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.MOVEMENT_CANNOT_FOR_THE_FUTURE);
        }
    }
}
