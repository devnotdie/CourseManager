using CourseManager.Domain.Common;

namespace CourseManager.Domain.Entities
{
    public class Course : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}