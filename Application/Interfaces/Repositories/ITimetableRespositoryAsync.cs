using CourseManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseManager.Application.Interfaces.Repositories
{
    public interface ITimetableRespositoryAsync : IRepositoryAsync<Timetable>
    {
        public Task<IEnumerable<Timetable>> GetAllTimetablesAsync();

        public Task<bool> ExistsCourseAsync(Guid courseId);
    }
}