using CourseManager.Domain.Common;
using System;

namespace CourseManager.Domain.Entities
{
    public class Timetable : AuditableBaseEntity
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartCourse { get; set; }
        public TimeSpan EndCourse { get; set; }
    }
}