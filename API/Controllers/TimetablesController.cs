using API.Controllers.Common;
using CourseManager.Application.Features.Timetables.Commands.CreateTimetable;
using CourseManager.Application.Features.Timetables.Queries.GetAllTimetables;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TimetablesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await Mediator.Send(new GetAllTimetablesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTimetableCommand request)
        {
            return Json(await Mediator.Send(request));
        }
    }
}