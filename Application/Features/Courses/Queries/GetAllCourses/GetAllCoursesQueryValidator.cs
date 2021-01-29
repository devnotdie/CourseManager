using FluentValidation;

namespace CourseManager.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesQueryValidator : AbstractValidator<GetAllCoursesQuery>
    {
        public GetAllCoursesQueryValidator()
        {
            RuleFor(e => e.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Field '{PropertyName}' must be greater or equal '{ComparisonValue}'")
                .WithName("pageNumber");

            RuleFor(e => e.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Field '{PropertyName}' must be greater or equal '{ComparisonValue}'")
                .WithName("pageSize");
        }
    }
}