using AutoMapper;
using CourseManager.Application.Interfaces.Repositories;
using CourseManager.Application.Wrappers;
using CourseManager.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManager.Application.Features.Timetables.Commands.CreateTimetable
{
    public class CreateTimetableCommand : IRequest<Response<Guid>>
    {
        public Guid CourseId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string StartCourse { get; set; }
        public string EndCourse { get; set; }
    }

    public class CreateTimetableCommandHandler : IRequestHandler<CreateTimetableCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly ITimetableRespositoryAsync _timetableRespositoryAsync;

        public CreateTimetableCommandHandler(IMapper mapper, ITimetableRespositoryAsync timetableRespositoryAsync)
        {
            _mapper = mapper;
            _timetableRespositoryAsync = timetableRespositoryAsync;
        }

        public async Task<Response<Guid>> Handle(CreateTimetableCommand request, CancellationToken cancellationToken)
        {
            var timetable = _mapper.Map<Timetable>(request);
            await _timetableRespositoryAsync.AddAsync(timetable);
            return new Response<Guid>(timetable.Id);
        }
    }
}