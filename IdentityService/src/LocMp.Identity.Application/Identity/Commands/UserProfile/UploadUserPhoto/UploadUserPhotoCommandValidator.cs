using FluentValidation;

namespace LocMp.Identity.Application.Identity.Commands.UserProfile.UploadUserPhoto;

public sealed class UploadUserPhotoCommandValidator : AbstractValidator<UploadUserPhotoCommand>
{
    private static readonly string[] AllowedMimeTypes =
    [
        "image/jpeg",
        "image/jpg",
        "image/png",
        "image/webp"
    ];

    private const int MaxPhotoSize = 5 * 1024 * 1024;

    public UploadUserPhotoCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Photo)
            .NotNull().WithMessage("File is required")
            .DependentRules(() =>
            {
                RuleFor(x => x.Photo.Length)
                    .LessThanOrEqualTo(MaxPhotoSize)
                    .WithMessage($"File size must not exceed {MaxPhotoSize / 1024 / 1024} MB.");

                RuleFor(x => x.Photo.ContentType)
                    .Must(contentType => AllowedMimeTypes.Contains(contentType?.ToLowerInvariant()))
                    .WithMessage("Allowed formats are JPEG, JPG, PNG, and WebP.");

                RuleFor(x => x.Photo.Length)
                    .GreaterThan(0)
                    .WithMessage("File is empty.");
            });
    }
}