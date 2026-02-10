using FluentValidation;

namespace LocMp.Identity.Application.Identity.Commands.Users.DeleteUser;

public sealed class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}