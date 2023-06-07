using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Domain.Enums;
using System.Net.Sockets;
using System.Xml.Linq;
using Task = Regista.Domain.Entities.Task;
using TaskStatus = Regista.Domain.Enums.TaskStatus;

namespace Regista1.WebApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly IUnitOfWork uow;
        public TaskController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<object> GetList(DataSourceLoadOptions options)
        {
            var models = await uow.taskRepository.Getlist();
            return DataSourceLoader.Load(models, options);
        }
        public async Task<IActionResult> AddTask(string values)
        {
            var model = JsonConvert.DeserializeObject<Task>(values);
           // await uow.taskRepository.AddTask(model);
            var task = new Task()
            {
                PlanedStart = DateTime.Now,
                PlanedEnd = DateTime.Now.AddDays(7),
            };
             await uow.taskRepository.AddTask(task);
            return Ok();
        }
        public async Task<string> TaskUpdate(int Key, string values)
        {
            var size = await uow.repository.GetById<Task>(Key);
            JsonConvert.PopulateObject(values, size);
            uow.taskRepository.Update(size);
            await uow.SaveChanges();

            return "1";
        }
        public async Task<string> Delete(int Key)
        {
            try
            {
                await uow.repository.Delete<Task>(Key);
                await uow.SaveChanges();
                return "1";

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
                var responsibleHelpers = await uow.userRepository.GetResponsible();
                return DataSourceLoader.Load(responsibleHelpers, loadOptions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ActionResult> GetTaskStatus()
        {
            try
            {
                var models = uow.repository.GetEnumSelect<TaskStatus>();
                var resultJson = JsonConvert.SerializeObject(models);
                return Content(resultJson, "application/json");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IActionResult> GetPriorityStatus()
        {
            try
            {
                var models = uow.repository.GetEnumSelect<PriorityStatus>();
                var resultJson = JsonConvert.SerializeObject(models);
                return Content(resultJson, "application/json");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
