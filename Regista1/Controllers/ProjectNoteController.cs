using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;
using Regista.Infasctructure.Repositories;

namespace Regista1.WebApp.Controllers
{
    public class ProjectNoteController : Controller
    {
        private readonly IUnitOfWork uow;

        public ProjectNoteController(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<object> GetList(DataSourceLoadOptions options)

        {
            var models = await uow.projectNoteRepository.GetList();
            return DataSourceLoader.Load(models, options);
        }
    }
}
