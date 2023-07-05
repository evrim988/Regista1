using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Regista.Application.Repositories;
using Regista.Application.Services.EmailServices;
using Regista.Domain.Dto.EmailModels;
using Regista.Domain.Dto.ResponsibleHelperModels;
using Regista.Domain.Entities;
using Regista.Infasctructure.Services.EmailServices;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Task = Regista.Domain.Entities.Task;

namespace Regista.Infasctructure.Repositories
{
    public class TaskRepository : Repository, ITaskRepository
    {
        private readonly RegistaContext context;
        private readonly SessionModel session;
        private readonly IUnitOfWork uow;
        private readonly IEmailServices emailService;

        public TaskRepository(RegistaContext _context,SessionModel _session,IUnitOfWork _uow,IEmailServices _emailServices) : base(_context,_session)
        {
            context = _context;
            session = _session;
            uow = _uow;
            emailService = _emailServices;
        }

        public async Task<IQueryable<Task>> Getlist()
        {
            var model = GetNonDeletedAndActive<Task>(t => true);
            return model;
        }

        public async Task<string> AddTask(Task model)
        {
            try
            {
                model.CustomerID = session.CustomerID;
                await uow.repository.Add(model);
                await uow.SaveChanges();
                return "";
            }
            catch (Exception e)
            {
                throw e;
            }
         
        }
        public async Task<string> TaskUpdate(Task model)
        {
            Update(model);
            await uow.SaveChanges();
            return "";
        }
        public void Delete(int id)
        {
            var task = GetNonDeletedAndActive<Task>(t => t.ID == id);
            DeleteRange(task.ToList());
            Delete<Customer>(id);
        }

        public async Task<string> SendMail(Task task)
        {
            try
            {
                //var UserCustomer = await GetByID<User>(user.ID);
                var UserCustomer = context.Users.Include(t => t.Customer).FirstOrDefault(t => t.ID == session.ID);
                var customer = await GetById<Customer>(task.CustomerID);


                EmailSendDto email = new EmailSendDto();
                email.To = "evrim@etkinbilgi.com";
                email.Body = "Bildirim : " + task.title + " / " + task.description;
                email.Subject = "Yeni Bildirim";

                emailService.Send(email, customer);

                return "1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SelectListItem>> ResponsiblehelperModelList()
        {
            try
            {
                return GetNonDeletedAndActive<User>(t => true)
                    .Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.Name + s.SurName}).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<SelectListItem>> RequestModelList()
        {
            try
            {
                return GetNonDeletedAndActive<Request>(t => true)
                    .Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.RequestName }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IQueryable<Task>> GetMyTaskUserID()
        {
            try
            {
                var model = GetNonDeletedAndActive<Task>(t => t.ResponsibleID == session.ID);
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> MyTaskUpdate(int Key, string values)
        {
            try
            {
                var TaskModel = context.Tasks.FirstOrDefault(t => t.ID == Key);

                var task = JsonConvert.DeserializeObject<Task>(values);

                if (task.TaskStatus != null)
                    TaskModel.TaskStatus = task.TaskStatus;

                return "1";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<ResponsibleDevextremeSelectListHelper>> GetRequest()
        {
            try
            {
                List<ResponsibleDevextremeSelectListHelper> ResponsibleHelpers = new List<ResponsibleDevextremeSelectListHelper>();
                var model = context.requests
                    .Where(t => true);
                foreach (var item in model)
                {
                    ResponsibleDevextremeSelectListHelper helper = new ResponsibleDevextremeSelectListHelper()
                    {
                        ID = item.ID,
                        Name = item.RequestName,
                    };
                    ResponsibleHelpers.Add(helper);
                }
                return ResponsibleHelpers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
