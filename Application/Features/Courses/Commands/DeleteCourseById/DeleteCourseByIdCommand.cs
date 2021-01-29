using CourseManager.Application.Interfaces.Repositories;
using CourseManager.Application.Wrappers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManager.Application.Features.Courses.Commands.DeleteCourseById
{
    public class DeleteCourseByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteCourseByIdCommandHandler : IRequestHandler<DeleteCourseByIdCommand, Response<Guid>>
    {
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;

        public DeleteCourseByIdCommandHandler(ICourseRepositoryAsync courseRepositoryAsync)
        {
            _courseRepositoryAsync = courseRepositoryAsync;
        }

        public async Task<Response<Guid>> Handle(DeleteCourseByIdCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepositoryAsync.GetAsync(request.Id);
            if (course is null)
            {
                throw new InvalidOperationException("Course not found.");
            }
            await _courseRepositoryAsync.RemoveAsync(course);
            return new Response<Guid>(course.Id);
        }
    }
}