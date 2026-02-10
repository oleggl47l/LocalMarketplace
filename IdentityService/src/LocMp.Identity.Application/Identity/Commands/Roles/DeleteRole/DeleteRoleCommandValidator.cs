using FluentValidation;

namespace LocMp.Identity.Application.Identity.Commands.Roles.DeleteRole;

public sealed class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}