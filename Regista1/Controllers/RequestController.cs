﻿using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Domain.Enums;
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

        public async Task<IActionResult> GetRequestDetail(int ID)
        {
<<<<<<< HEAD
            return View();
=======
            var models = await uow.requestRepository.GetActionDetail(ID);
            return Ok(models);
>>>>>>> 50341c1ffca980883816b4591b11e4d7689707d3
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
        public async Task<IActionResult> GetCategoryStatus()
        {
            try
            {
                var models = uow.repository.GetEnumSelect<CategoryStatus>();
                var resultJson = JsonConvert.SerializeObject(models);
                return Content(resultJson, "application/json");
            }
            catch (Exception e)
            {
                throw e;
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
    }
}
