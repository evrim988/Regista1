using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Domain.Dto.ActionModels;
using Regista.Domain.Entities;
using Regista.Domain.Enums;

namespace Regista.WebApp.Controllers
{
    public class ActionController : Controller
    {
        private readonly IUnitOfWork _uow;
        public ActionController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ActionDTO();
            model.ResponsiblehelperModelList = await _uow.actionRepository.ResponsiblehelperModelList();
            model.OpeningDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            return View(model);
        }

        public async Task<object> GetList(DataSourceLoadOptions options)
        {
            try
            {
                var model = _uow.actionRepository.GetList();
                return DataSourceLoader.Load(model, options);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IActionResult> AddAction(string values)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<Regista.Domain.Entities.Action>(values);
                await _uow.actionRepository.AddActions(model);
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> ActionUpdate(int key,string values)
        {
            try
            {
                var model = await _uow.repository.GetById<Regista.Domain.Entities.Action>(key);
                JsonConvert.PopulateObject(values, model);
                await _uow.actionRepository.ActionsUpdate(model);
                await _uow.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> DeleteAction(int key)
        {
            try
            {
                await _uow.repository.Delete<Regista.Domain.Entities.Action>(key);
                await _uow.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IActionResult> Detail (int ID)
        {
            var actionDetail = await _uow.actionRepository.GetAction(ID);
            return View(actionDetail);
        }
        public async Task<IActionResult> GetActionStatus()
        {
            try
            {
                var models = _uow.repository.GetEnumSelect<ActionStatus>();
                var resultJson = JsonConvert.SerializeObject(models);
                return Content(resultJson, "application/json");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> GetResponsible(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var model = await _uow.userRepository.GetResponsible();
                return DataSourceLoader.Load(model, loadOptions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> GetRequest(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var model = await _uow.actionRepository.GetRequest();
                return DataSourceLoader.Load(model, loadOptions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
