using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;
using Regista.Infasctructure.Repositories;
using Regista.Persistance.Db;

namespace Regista1.WebApp.Controllers
{
    public class RequestController : Controller
    {
        private readonly IUnitOfWork uow;

        public RequestController(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<object> GetList(DataSourceLoadOptions options)

        {
            var models = await uow.requestRepository.GetList();
            return DataSourceLoader.Load(models, options);
        }

    }
}
