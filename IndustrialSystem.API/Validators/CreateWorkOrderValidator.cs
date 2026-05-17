using FluentValidation;
using IndustrialSystem.API.DTOs;

namespace IndustrialSystem.API.Validators;

public class CreateWorkOrderValidator : AbstractValidator<CreateWorkOrderDto>
{
    public CreateWorkOrderValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(5);
    }
}
