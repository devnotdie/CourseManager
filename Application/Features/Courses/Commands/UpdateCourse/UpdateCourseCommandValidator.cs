using FluentValidation;

namespace CourseManager.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithMessage("Field '{PropertyName}' Incorrect ID.")
                .WithName("id");

            RuleFor(e => e.Name)
             .NotNull().WithMessage("Field '{PropertyName}' not be empty")
             .NotEmpty().WithMessage("Field '{PropertyName}' not be empty")
             .WithName("name");

            RuleFor(e => e.Price)
                .GreaterThanOrEqualTo(50).WithMessage("Field '{PropertyName}' must be greater or equal '{ComparisonValue}'")
                .WithName("price");
        }
    }
}