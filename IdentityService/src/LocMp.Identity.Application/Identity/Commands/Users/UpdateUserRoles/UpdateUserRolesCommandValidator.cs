using FluentValidation;

namespace LocMp.Identity.Application.Identity.Commands.Users.UpdateUserRoles;

public sealed class UpdateUserRolesCommandValidator : AbstractValidator<UpdateUserRolesCommand>
{
    public UpdateUserRolesCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Roles)
            .NotNull()
            .Must(roles => roles.Count != 0)
            .WithMessage("A user must have at least one role.");
    }
}