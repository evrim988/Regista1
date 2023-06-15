using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Domain.Dto.Entities.UserModel;
using Regista.Domain.Entities;

namespace Regista1.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork uow;
        public UserController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public async Task<object> GetList(DataSourceLoadOptions options)

        {
            var models = await uow.userRepository.GetList();
            return DataSourceLoader.Load(models, options);
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddUser(string values)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<User>(values);
                await uow.userRepository.AddUser(model);
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<string> UserEdit(int Key, string values)
        {
            try
            {
                var size = await uow.repository.GetById<User>(Key);
                JsonConvert.PopulateObject(values, size);
                uow.userRepository.Update(size);
                await uow.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> DeleteUser(int Key)
        {
            try
            {
                await uow.repository.Delete<User>(Key);
                await uow.SaveChanges();
                return "1";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public async Task<IActionResult> UserDetail()
        {
            try
            {
                var model = await uow.userRepository.GetById<User>(uow.GetSession().ID);

                var userdetail = new UserDetailDto()
                {
                    ID = model.ID.ToString(),
                    UserName = model.UserName,
                    Name = model.Name,
                    Surname = model.SurName,
                    Parola = model.password,
                    Email = model.EMail,
                };

                return View(userdetail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UserDetail(UserDetailDto userDetail)
        {
            try
            {
                var model = await uow.userRepository.GetById<User>(uow.GetSession().ID);

                model.UserName = userDetail.UserName;
                model.Name = userDetail.Name;
                model.password = userDetail.Parola;
                model.EMail = userDetail.Email;


                uow.userRepository.Update<User>(model);
                await uow.SaveChanges();


                return RedirectToAction("Login", "Security");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
