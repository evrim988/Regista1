using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Domain.Entities;

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
        [HttpGet]
        public async Task<object> GetModules(DataSourceLoadOptions options)
        {
            try
            {
                var model = await _uow.modulesRepository.GetModules();
                return DataSourceLoader.Load(model, options);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> AddModules(string values)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<Modules>(values);
                await _uow.modulesRepository.CreateModules(model);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> ModulesUpdate(int key,string values)
        {
            try
            {
                var model = await _uow.repository.GetById<Modules>(key);
                JsonConvert.PopulateObject(values, model);
                await _uow.modulesRepository.UpdatesModules(model);
                await _uow.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> DeleteModules(int key)
        {
            try
            {
                await _uow.repository.Delete<Modules>(key);
                await _uow.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
