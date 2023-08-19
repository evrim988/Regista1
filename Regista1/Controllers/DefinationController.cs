using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Domain.Enums;
using Version = Regista.Domain.Entities.Version;

namespace Regista.WebApp.Controllers
{
    public class DefinationController : Controller
    {
        private readonly IUnitOfWork _uow;
        public DefinationController(IUnitOfWork uow)
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

        public async Task<IActionResult> ModulesUpdate(int key, string values)
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

        public async Task<object> GetVersion(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var model = await _uow.versionRepository.GetList();
                return DataSourceLoader.Load(model, loadOptions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> AddVersion(string values)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<Version>(values);
                await _uow.versionRepository.AddVersion(model);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> UpdateVersion(int key,string values)
        {
            try
            {
                var model=await _uow.repository.GetById<Version>(key);
                JsonConvert.PopulateObject(values, model);
                await _uow.versionRepository.UpdateVersion(model);
                await _uow.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> DeleteVersion(int key)
        {
            try
            {
                await _uow.repository.Delete<Version>(key);
                await _uow.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> GetDatabaseStatus()
        {
            try
            {
                var model = _uow.repository.GetEnumSelect<DatabaseChangeStatus>();
                var resultjson = JsonConvert.SerializeObject(model);
                return Content(resultjson, "application/json");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
