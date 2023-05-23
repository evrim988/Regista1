using Regista.Domain.ResponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Repositories
{
    public interface IRepository<T>
    {
        public Task<BaseResponse<T>> Add(T model);
        public Task<BaseResponse<T>> Update(T model);
        public Task<BaseResponse<T>> Delete(T model);
        public Task<BaseResponse<T>> GetById(int id);
        public Task<BaseResponse<T>> GetList();
    }
}
