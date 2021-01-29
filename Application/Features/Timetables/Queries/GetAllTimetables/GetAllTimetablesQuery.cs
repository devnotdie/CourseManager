using AutoMapper;
using CourseManager.Application.DTOs;
using CourseManager.Application.Interfaces.Repositories;
using CourseManager.Application.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManager.Application.Features.Timetables.Queries.GetAllTimetables
{
    public class GetAllTimetablesQuery : IRequest<Response<IEnumerable<TimetableDto>>>
    {
    }

    public class GetAllTimetablesQueryHandler : IRequestHandler<GetAllTimetablesQuery, Response<IEnumerable<TimetableDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ITimetableRespositoryAsync _timetableRespositoryAsync;

        public GetAllTimetablesQueryHandler(IMapper mapper, ITimetableRespositoryAsync timetableRespositoryAsync)
        {
            _mapper = mapper;
            _timetableRespositoryAsync = timetableRespositoryAsync;
        }

        public async Task<Response<IEnumerable<TimetableDto>>> Handle(GetAllTimetablesQuery request, CancellationToken cancellationToken)
        {
            var timetables = await _timetableRespositoryAsync.GetAllTimetablesAsync();
            var timetablesDto = _mapper.Map<IEnumerable<TimetableDto>>(timetables);
            return new Response<IEnumerable<TimetableDto>>(timetablesDto);
        }
    }
}