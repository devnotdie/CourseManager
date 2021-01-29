using CourseManager.Application.Wrappers;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : Controller
    {
        [Route("error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var response = new Response<string>();

            if (exception is ValidationException)
            {
                var validationException = exception as ValidationException;
                response.Message = "Validation failed";
                response.Errors = validationException.Errors.Select(e => e.ErrorMessage).ToList();
                Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else
            {
                Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                response.Message = exception.Message;
            }

            return Json(response);
        }
    }
}