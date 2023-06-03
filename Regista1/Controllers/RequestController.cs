using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Domain.Entities;
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
        public async Task<string> RequestDelete(int Key)
        {
            try
            {
                await uow.repository.Delete<Request>(Key);
                await uow.SaveChanges();
                return "1";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
