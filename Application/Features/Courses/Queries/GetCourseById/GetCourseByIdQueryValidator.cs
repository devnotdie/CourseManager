using FluentValidation;

namespace CourseManager.Application.Features.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQueryValidator : AbstractValidator<GetCourseByIdQuery>
    {
        public GetCourseByIdQueryValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithMessage("Incorrect ID.");
        }
    }
}