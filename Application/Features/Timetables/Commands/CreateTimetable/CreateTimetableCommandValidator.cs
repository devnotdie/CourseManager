using CourseManager.Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManager.Application.Features.Timetables.Commands.CreateTimetable
{
    public class CreateTimetableCommandValidator : AbstractValidator<CreateTimetableCommand>
    {
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;
        private readonly ITimetableRespositoryAsync _timetableRespositoryAsync;

        public CreateTimetableCommandValidator(ICourseRepositoryAsync courseRepositoryAsync,
            ITimetableRespositoryAsync timetableRespositoryAsync)
        {
            _courseRepositoryAsync = courseRepositoryAsync;
            _timetableRespositoryAsync = timetableRespositoryAsync;

            RuleFor(e => e.CourseId)
                .NotEmpty().WithMessage("Field '{PropertyName}' not be empty")
                .MustAsync(ExistsCourseAsync).WithMessage("Field '{PropertyName}' Course not found")
                .MustAsync(CourseUsedInTimetableAsync).WithMessage("Course already added")
                .WithName("courseId");

            RuleFor(e => e.DayOfWeek)
                .Must(ValidationRangeDayOfWeek).WithMessage("Field '{PropertyName}' has incorrect value")
                .Must(ValidationDayOfWeek).WithMessage("Field '{PropertyName}' must not be 'Saturday' or 'Sunday'")
                .WithName("dayOfWeek");

            RuleFor(e => e.StartCourse)
                .NotNull().WithMessage("Field '{PropertyName}' not be empty")
                .NotEmpty().WithMessage("Field '{PropertyName}' not be empty")
                .Must(TryParseTime).WithMessage("Field '{PropertyName}' incorrect format. Example '12:00:00'")
                .Must(ValidationOfСourseTime).WithMessage("Field '{PropertyName}' time must be greater 09:00:00 and less 17:00:00")
                .WithName("startCourse");

            RuleFor(e => e.EndCourse)
               .NotNull().WithMessage("Field '{PropertyName}' not be empty")
               .NotEmpty().WithMessage("Field '{PropertyName}' not be empty")
               .Must(TryParseTime).WithMessage("Field '{PropertyName}' incorrect format. Example '12:00:00'")
               .Must(ValidationOfСourseTime).WithMessage("Field '{PropertyName}' time must be greater 09:00:00 and less 17:00:00")
               .WithName("endCourse");
        }

        private async Task<bool> ExistsCourseAsync(Guid courseId, CancellationToken cancellationToken)
        {
            return await _courseRepositoryAsync.ExistsCourseAsync(courseId);
        }

        private async Task<bool> CourseUsedInTimetableAsync(Guid courseId, CancellationToken cancellationToken)
        {
            return !await _timetableRespositoryAsync.ExistsCourseAsync(courseId);
        }

        private bool ValidationRangeDayOfWeek(DayOfWeek dayOfWeek)
        {
            var values = Enum.GetValues(typeof(DayOfWeek)).Cast<int>();
            return values.Contains((int)dayOfWeek);
        }

        private bool ValidationDayOfWeek(DayOfWeek dayOfWeek)
        {
            return dayOfWeek != DayOfWeek.Sunday && dayOfWeek != DayOfWeek.Saturday;
        }

        private bool TryParseTime(string time)
        {
            return TimeSpan.TryParse(time, out var result);
        }

        private bool ValidationOfСourseTime(string time)
        {
            if (TimeSpan.TryParse(time, out var result))
            {
                return result.Hours > 9 && result.Hours < 17;
            }

            return false;
        }
    }
}