using Regista.Domain.Dto.ResponsibleHelperModels;
using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Repositories
{
    public interface IUserRepository : IRepository
    {
        public Task<string> AddUser(User user);
        public void Delete(int id);
        public Task<IQueryable<User>> GetList();
        Task<List<ResponsibleDevextremeSelectListHelper>> GetResponsible();
    }
}
