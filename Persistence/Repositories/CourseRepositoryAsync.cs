using CourseManager.Application.Interfaces.Repositories;
using CourseManager.Domain.Entities;
using CourseManager.Persistence.Common;
using CourseManager.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CourseManager.Persistence.Repositories
{
    public class CourseRepositoryAsync : RepositoryAsync<Course>, ICourseRepositoryAsync
    {
        private DbSet<Course> _courses;

        public CourseRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _courses = dbContext.Courses;
        }

        public async Task<bool> ExistsCourseAsync(Guid id)
        {
            return await _courses.AnyAsync(e => e.Id == id);
        }
    }
}