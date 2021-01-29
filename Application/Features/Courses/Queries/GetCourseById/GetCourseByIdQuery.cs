using AutoMapper;
using CourseManager.Application.DTOs;
using CourseManager.Application.Interfaces.Repositories;
using CourseManager.Application.Wrappers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManager.Application.Features.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQuery : IRequest<Response<CourseDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Response<CourseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;

        public GetCourseByIdQueryHandler(IMapper mapper, ICourseRepositoryAsync courseRepositoryAsync)
        {
            _mapper = mapper;
            _courseRepositoryAsync = courseRepositoryAsync;
        }

        public async Task<Response<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepositoryAsync.GetAsync(request.Id);
            var courseDto = _mapper.Map<CourseDto>(course);

            return new Response<CourseDto>(courseDto);
        }
    }
}