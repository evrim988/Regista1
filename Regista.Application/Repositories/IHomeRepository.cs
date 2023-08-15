using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Regista.Domain.Entities.Task;

namespace Regista.Application.Repositories
{
    public interface IHomeRepository : IRepository
    {
        public Task<IQueryable<Task>> GetTaskHome();
        public Task<IQueryable<Domain.Entities.Action>> GetActionHome();
    }
}
