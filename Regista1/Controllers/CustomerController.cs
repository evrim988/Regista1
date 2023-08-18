using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Domain.Entities;
using static DevExpress.Data.Helpers.ExpressiveSortInfo;

namespace Regista.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork uow;
        public CustomerController(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }

        public async Task<object> GetList(DataSourceLoadOptions options)

        {
            var models = await uow.customerRepository.GetList();
            return DataSourceLoader.Load(models, options);
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CustomerAdd(string values)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<Customer>(values);
                await uow.customerRepository.CustomerAdd(model);
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }
        public async Task<string> CustomerEdit(int Key, string values)
        {
            try
            {
                var size = await uow.repository.GetById<Customer>(Key);
                JsonConvert.PopulateObject(values, size);
                uow.customerRepository.Update(size);
                await uow.SaveChanges();

                return "1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> DeleteCustomer(int Key)
        {
            try
            {
                await uow.repository.Delete<Customer>(Key);
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
