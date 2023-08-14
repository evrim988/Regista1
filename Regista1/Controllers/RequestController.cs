using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Domain.Enums;
using Regista.Infasctructure.Repositories;
using Regista.Persistance.Db;
using System.Xml.Linq;

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

        public async Task<IActionResult> GetRequestDetail(int ID)
        {
            var models = await uow.requestRepository.GetActionDetail(ID);
            return Ok(models);
        }

        public async Task<IActionResult> RequestAdd(string values)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<Request>(values);
                await uow.requestRepository.RequestAdd(model);
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<string> RequestEdit(int Key, string values)
        {
            try
            {
                var size = await uow.repository.GetById<Request>(Key);
                JsonConvert.PopulateObject(values, size);
                uow.requestRepository.Update(size);
                await uow.SaveChanges();

                return "1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> RequestDelete(int Key)
        {
            try
            {
                await uow.repository.Delete<Request>(Key);
                await uow.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IActionResult> AddActionItem(string values,int ID)
        {
            var model = JsonConvert.DeserializeObject<Actions>(values);
            model.RequestID = ID;
            await uow.actionRepository.AddActions(model);
            return Ok(model);
        }
        [HttpPut]
        public async Task<IActionResult> EditActionItem(int key,string values,int ID)
        {
            var model = await uow.repository.GetById<Actions>(key);
            JsonConvert.PopulateObject(values, model);
            await uow.actionRepository.ActionsUpdate(model);
            return Ok();
        }

        public async Task<string> DeleteActionItem(int key)
        {
            try
            {
                await uow.repository.Delete<Actions>(key);
                await uow.SaveChanges();
                return "";
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> GetCategoryStatus()
        {
            try
            {
                var models = uow.repository.GetEnumSelect<CategoryStatus>();
                var resultJson = JsonConvert.SerializeObject(models);
                return Content(resultJson, "application/json");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> GetRequestStatus()
        {
            try
            {
                var models = uow.repository.GetEnumSelect<RequestStatus>();
                var resultJson = JsonConvert.SerializeObject(models);
                return Content(resultJson, "application/json");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> GetProject(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var responsibleHelpers = await uow.requestRepository.GetProject();
                return DataSourceLoader.Load(responsibleHelpers, loadOptions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> GetModules(DataSourceLoadOptions options)
        {
            try
            {
                var model = await uow.requestRepository.GetModuleSelect();
                return DataSourceLoader.Load(model, options);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> GetCustomer(DataSourceLoadOptions loadOptions)
        {
            try
            {
                var model = await uow.requestRepository.GetCustomer();
                return DataSourceLoader.Load(model, loadOptions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<SelectListItem>> GetNotificationType()
        {
            return await uow.requestRepository.NotificationTypeSelectList();
        }
        public async Task<List<SelectListItem>> GetCategorySelect()
        {
            return await uow.requestRepository.CategorySelectList();
        }
    }
}
