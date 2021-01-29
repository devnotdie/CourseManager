using CourseManager.Application.Interfaces.Repositories;
using CourseManager.Application.Wrappers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManager.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Response<Guid>>
    {
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;

        public UpdateCourseCommandHandler(ICourseRepositoryAsync courseRepositoryAsync)
        {
            _courseRepositoryAsync = courseRepositoryAsync;
        }

        public async Task<Response<Guid>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepositoryAsync.GetAsync(request.Id);
            if (course is null)
            {
                throw new InvalidOperationException("Course not found.");
            }

            course.Name = request.Name;
            course.Description = request.Description;
            course.Price = request.Price;
            await _courseRepositoryAsync.UpdateAsync(course);
            return new Response<Guid>(course.Id);
        }
    }
}