using Regista.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Application.Repositories
{
    public interface ICustomerRepository : IRepository
    {
        public Task<IQueryable<Customer>> GetList();
        public Task<string> Add(Customer model);
        public void Delete(int id);
    }
}
