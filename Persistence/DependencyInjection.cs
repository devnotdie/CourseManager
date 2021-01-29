using CourseManager.Application.Interfaces;
using CourseManager.Application.Interfaces.Repositories;
using CourseManager.Persistence.Common;
using CourseManager.Persistence.Contexts;
using CourseManager.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseManager.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<ICourseRepositoryAsync, CourseRepositoryAsync>();
            services.AddTransient<ITimetableRespositoryAsync, TimetableRespositoryAsync>();

            return services;
        }
    }
}