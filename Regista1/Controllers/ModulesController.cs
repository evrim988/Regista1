using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;

namespace Regista1.WebApp.Controllers
{
    public class ModulesController : Controller
    {
        private readonly IUnitOfWork _uow;
        public ModulesController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
