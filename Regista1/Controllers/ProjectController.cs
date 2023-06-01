using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Domain.Entities;

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
            var models = await uow.projectRepository.GetList();
            return DataSourceLoader.Load(models, options);
        }
        public async Task<IActionResult> AddProject(string values)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<Project>(values);
                await uow.projectRepository.AddProject(model);
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
