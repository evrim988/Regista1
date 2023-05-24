using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;

namespace Regista1.WebApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork uow;
        public ProjectController(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }
        public async Task<object> GetList(DataSourceLoadOptions options)

        {
            var models = await uow.customerRepository.GetList();
            return DataSourceLoader.Load(models, options);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
