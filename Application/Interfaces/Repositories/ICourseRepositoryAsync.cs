using CourseManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CourseManager.Application.Interfaces.Repositories
{
    public interface ICourseRepositoryAsync : IRepositoryAsync<Course>
    {
        public Task<bool> ExistsCourseAsync(Guid id);
    }
}