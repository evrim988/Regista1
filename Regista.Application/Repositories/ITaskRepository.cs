using Microsoft.AspNetCore.Mvc.Rendering;
using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Task = Regista.Domain.Entities.Task;

namespace Regista.Application.Repositories
{
    public interface ITaskRepository : IRepository
    {
        public Task<IQueryable<Task>> Getlist();
        public Task<IQueryable<Task>> GetMyTaskUserID();
        public Task<string> AddTask(Task task);
        public Task<string> TaskUpdate(Task task);
        Task<string> MyTaskUpdate(int Key, string values);
        public void Delete(int id);
        public Task<string> SendMail(Task task);
        public Task<List<SelectListItem>> ResponsiblehelperModelList();
    }
}
