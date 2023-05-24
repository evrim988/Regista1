using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Regista.Application.Repositories;
using Regista.Domain.Entities;
using static DevExpress.Data.Helpers.ExpressiveSortInfo;

namespace Regista1.WebApp.Controllers
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

        //[HttpPost]
        //public async Task<IActionResult> Add(Customer model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    //var result = await _customerRepository.Add(model);

        //    //ViewBag.Result = result;

        //    return View(model);
        //}


        //public async Task<object> Update(int id)
        //{
        //    var customer = await uow.customerRepository.GetById(id);

        //    if (customer.ResultObject == null)
        //        return RedirectToAction(nameof(GetList));

        //    return View(customer.ResultObject);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(Customer model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    //var result = await _customerRepository.Update(model);

        //    //ViewBag.Result = result;

        //    return View(model);
        //}
    }
}
