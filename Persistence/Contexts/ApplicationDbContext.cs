using CourseManager.Domain.Common;
using CourseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseManager.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Timetable> Timetables { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var courseId = Guid.NewGuid();

            modelBuilder.Entity<Course>().HasData(
                new Course[]
                {
                    new Course { Id = Guid.NewGuid(), Name="Angular", Price = 215, CreatedOn = DateTime.UtcNow},
                    new Course { Id = Guid.NewGuid(), Name="Asp.net", Price=26, CreatedOn = DateTime.UtcNow},
                    new Course { Id = courseId, Name="Maya", Price=28, CreatedOn = DateTime.UtcNow}
                });

            modelBuilder.Entity<Timetable>().HasData(
                new Timetable
                {
                    Id = Guid.NewGuid(),
                    CourseId = courseId,
                    DayOfWeek = DayOfWeek.Wednesday,
                    StartCourse = TimeSpan.Parse("10:00:00"),
                    EndCourse = TimeSpan.Parse("12:00:00"),
                    CreatedOn = DateTime.UtcNow
                });
        }
    }
}