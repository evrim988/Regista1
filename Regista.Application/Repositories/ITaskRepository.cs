using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Regista.Domain.Entities.Task;

namespace Regista.Application.Repositories
{
    public interface ITaskRepository : IRepository
    {
        public Task<IQueryable<Task>> Getlist();
        public Task<string> AddTask(Task task);
        public Task<string> TaskUpdate(Task task);
        public void Delete(int id);
    }
}
