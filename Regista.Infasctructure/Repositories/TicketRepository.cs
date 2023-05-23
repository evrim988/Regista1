using Regista.Application.Repositories;
using Regista.Domain.ResponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Repositories
{
    public class TicketRepository : ITaskRepository
    {
        public Task<BaseResponse<Task>> Add(Task model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Task>> Delete(Task model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Task>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Task>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Task>> Update(Task model)
        {
            throw new NotImplementedException();
        }
    }
}
