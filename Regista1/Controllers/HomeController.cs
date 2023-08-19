using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Regista.Application.Repositories;
using Regista.Models;
using Regista.WebApp.Filter;
using System.Diagnostics;

namespace Regista.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _uow;
        public HomeController(ILogger<HomeController> logger,IUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }
        [Auth]
        public IActionResult Index()
        {
            return View();
        }
        //[Auth]
        //public async Task<object> GetTaskHome(DataSourceLoadOptions options)
        //{
        //    var models = await _uow.homeRepository.GetTaskHome();
        //    return DataSourceLoader.Load(models, options);
        //}

        public async Task<object> GetActionHome(DataSourceLoadOptions options)
        {
            var models = await _uow.homeRepository.GetActionHome();
            return DataSourceLoader.Load(models, options);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}