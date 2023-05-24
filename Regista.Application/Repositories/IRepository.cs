using Regista.Domain.Entities;
using Regista.Domain.ResponseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Repositories
{
    public interface IRepository
    {
        Task<T>  Add<T>(T _object) where T : BaseEntitiy;
        T Update<T>(T _object) where T : BaseEntitiy;
        Task<T> Delete<T>(int id) where T : BaseEntitiy;
        Task<T> GetById<T>(int id) where T : BaseEntitiy;
        IQueryable<T> GetList<T>(Expression<Func<T, bool>> where) where T : BaseEntitiy;

    }
}
