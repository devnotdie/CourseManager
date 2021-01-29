using AutoMapper;
using CourseManager.Application.Interfaces.Repositories;
using CourseManager.Application.Wrappers;
using CourseManager.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManager.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;

        public CreateCourseCommandHandler(IMapper mapper, ICourseRepositoryAsync courseRepositoryAsync)
        {
            _mapper = mapper;
            _courseRepositoryAsync = courseRepositoryAsync;
        }

        public async Task<Response<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            await _courseRepositoryAsync.AddAsync(course);

            return new Response<Guid>(course.Id);
        }
    }
}