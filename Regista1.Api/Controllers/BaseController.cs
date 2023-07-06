using Microsoft.AspNetCore.Mvc;
using Registalaser.Domain.Exceptions;

namespace Regista1.Api.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult ErrorHandler(Exception error)
        {
            if (error is UnAuth)
                return Unauthorized(error.Message);
            if (error is CustomEx)
                return BadRequest(error.Message);
            else
                return BadRequest("Beklenmeyen Bir Hata Oluştu");
        }
    }
}
