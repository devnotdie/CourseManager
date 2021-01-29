using FluentValidation;

namespace CourseManager.Application.Features.Courses.Commands.DeleteCourseById
{
    public class DeleteCourseByIdCommandValidator : AbstractValidator<DeleteCourseByIdCommand>
    {
        public DeleteCourseByIdCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithMessage("Incorrect ID.");
        }
    }
}