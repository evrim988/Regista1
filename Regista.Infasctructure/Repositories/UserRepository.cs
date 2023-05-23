using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Domain.ResponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<BaseResponse<User>> Add(User model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> Delete(User model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<User>> Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
