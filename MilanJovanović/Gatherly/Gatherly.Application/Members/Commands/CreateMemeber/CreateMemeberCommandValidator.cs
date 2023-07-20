using FluentValidation;
using Gatherly.Domain.ValueObjects;

namespace Gatherly.Application.Members.Commands.CreateMemeber;

internal class CreateMemeberCommandValidator : AbstractValidator<CreateMemeberCommand>
{
    public CreateMemeberCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(FirstName.MaxLength);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(LastName.MaxLength);
    }
}