using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{   
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionController : ControllerBase
    {
        [HttpGet]
        [Route("/error")]
        public IActionResult HandleGlobalExceptions()
        {
            var Exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var StatusCode = Exception.Error.GetType().Name switch
            {
                "ArgumentException" => HttpStatusCode.BadRequest,
                "NullPointerException" => HttpStatusCode.InternalServerError,
                _ => HttpStatusCode.ServiceUnavailable
            };
            return Problem(detail:Exception.Error.Message, statusCode: (int) StatusCode);
        }
    }
}
