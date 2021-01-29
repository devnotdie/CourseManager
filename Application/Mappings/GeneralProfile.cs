using AutoMapper;
using CourseManager.Application.DTOs;
using CourseManager.Application.Features.Courses.Commands.CreateCourse;
using CourseManager.Application.Features.Timetables.Commands.CreateTimetable;
using CourseManager.Domain.Entities;
using System;

namespace CourseManager.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CreateCourseCommand, Course>();

            CreateMap<Timetable, TimetableDto>()
                 .ForPath(e => e.StartCourse, options => options.MapFrom(e => e.StartCourse.ToString()))
                .ForPath(e => e.EndCourse, options => options.MapFrom(e => e.EndCourse.ToString()));
            CreateMap<CreateTimetableCommand, Timetable>()
                .ForPath(e => e.StartCourse, options => options.MapFrom(e => TimeSpan.Parse(e.StartCourse)))
                .ForPath(e => e.EndCourse, options => options.MapFrom(e => TimeSpan.Parse(e.EndCourse)));
        }
    }
}