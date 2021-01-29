using AutoMapper;
using CourseManager.Application.DTOs;
using CourseManager.Application.Interfaces.Repositories;
using CourseManager.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManager.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesQuery : IRequest<PagedResponse<IEnumerable<CourseDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, PagedResponse<IEnumerable<CourseDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepositoryAsync _courseRepositoryAsync;

        public GetAllCoursesQueryHandler(IMapper mapper, ICourseRepositoryAsync courseRepositoryAsync)
        {
            _mapper = mapper;
            _courseRepositoryAsync = courseRepositoryAsync;
        }

        public async Task<PagedResponse<IEnumerable<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepositoryAsync.GetAllWithPaginationAsync(request.PageNumber, request.PageSize);
            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courses);

            return new PagedResponse<IEnumerable<CourseDto>>(coursesDto, request.PageNumber, request.PageSize);
        }
    }
}