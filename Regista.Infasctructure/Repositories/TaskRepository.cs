using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public TaskRepository(RegistaContext _context,SessionModel _session,IUnitOfWork _uow) : base(_context,_session)
        {
            context = _context;
            session = _session;
            uow = _uow;
        }

        public async Task<IQueryable<Task>> Getlist()
        {
            var model = GetNonDeletedAndActive<Task>(t => true);
            return model;
        }

        public async Task<string> AddTask(Task model)
        {
            model.CustomerID = session.CustomerID;
            await uow.repository.Add(model);
            await uow.SaveChanges();
            return "";
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

       
    }
}
