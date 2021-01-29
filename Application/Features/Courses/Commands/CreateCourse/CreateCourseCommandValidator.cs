using FluentValidation;

namespace CourseManager.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
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