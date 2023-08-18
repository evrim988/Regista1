using Microsoft.AspNetCore.Mvc;

namespace Regista.Api.Controllers
{
    public class VersionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
