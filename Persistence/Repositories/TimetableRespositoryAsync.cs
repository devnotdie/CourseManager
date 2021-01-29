using CourseManager.Application.Interfaces.Repositories;
using CourseManager.Domain.Entities;
using CourseManager.Persistence.Common;
using CourseManager.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseManager.Persistence.Repositories
{
    public class TimetableRespositoryAsync : RepositoryAsync<Timetable>, ITimetableRespositoryAsync
    {
        private DbSet<Timetable> _timetables;

        public TimetableRespositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _timetables = dbContext.Timetables;
        }

        public async Task<IEnumerable<Timetable>> GetAllTimetablesAsync()
        {
            return await _timetables
                .Include(e => e.Course)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ExistsCourseAsync(Guid courseId)
        {
            return await _timetables.AnyAsync(e => e.CourseId == courseId);
        }
    }
}