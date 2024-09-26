using FluentValidation;
using VooltChallenge.Application.Models;

namespace VooltChallenge.Application.Validators;

public sealed class AdValidator : AbstractValidator<Ad>
{
    public AdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(5);
    }
}
