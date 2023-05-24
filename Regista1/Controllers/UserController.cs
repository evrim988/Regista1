using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;

namespace Regista1.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork uow;
        public UserController(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }
        public async Task<object> GetList(DataSourceLoadOptions options)

        {
            var models = await uow.userRepository.GetList();
            return DataSourceLoader.Load(models, options);
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
