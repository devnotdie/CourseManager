using API.Controllers.Common;
using CourseManager.Application.Features.Courses.Commands.CreateCourse;
using CourseManager.Application.Features.Courses.Commands.DeleteCourseById;
using CourseManager.Application.Features.Courses.Commands.UpdateCourse;
using CourseManager.Application.Features.Courses.Queries.GetAllCourses;
using CourseManager.Application.Features.Courses.Queries.GetCourseById;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CoursesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery, Required] int pageNumber, [FromQuery, Required] int pageSize)
        {
            return Json(await Mediator.Send(new GetAllCoursesQuery { PageNumber = pageNumber, PageSize = pageSize }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Json(await Mediator.Send(new GetCourseByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCourseCommand request)
        {
            return Json(await Mediator.Send(request));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCourseCommand request)
        {
            return Json(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Json(await Mediator.Send(new DeleteCourseByIdCommand { Id = id }));
        }
    }
}