using FluentValidation;
using IndustrialSystem.API.DTOs;

namespace IndustrialSystem.API.Validators
{
    public class UpdateWorkOrderValidator : AbstractValidator<UpdateWorkOrderDto>
    {
        public UpdateWorkOrderValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Progress)
                .InclusiveBetween(0, 100).WithMessage("Progress must be between 0 and 100.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => new[] { "Pending", "InProgress", "Completed" }.Contains(status))
                .WithMessage("Status must be one of: Pending, InProgress, Completed.");
        }
    }
}
