using System;

namespace CourseManager.Application.DTOs
{
    public class TimetableDto
    {
        public Guid Id { get; set; }
        public CourseDto Course { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string StartCourse { get; set; }
        public string EndCourse { get; set; }
    }
}