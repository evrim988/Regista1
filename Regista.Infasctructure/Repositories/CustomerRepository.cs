using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Repositories
{
    public class CustomerRepository : Repository,ICustomerRepository
    {
        private readonly RegistaContext context;

        private readonly IUnitOfWork uow;

        public CustomerRepository(RegistaContext _context, IUnitOfWork _uow) : base(_context)
        {
            this.context = _context;
            this.uow = _uow;
        }

        public async Task<string> Add(int ID, string Name) 
        {
            var customer = new Customer()
            {
                Name = Name
            };
            await Add(customer);

            return "1";
        }

        public void Delete(int id) 
        {
           var customer = GetNonDeletedAndActive<Customer>(t => t.id == id);
           DeleteRange(customer.ToList());

            Delete<Customer>(id);
        }

        //public Task<IQueryable<Customer>> GetById(int id)
        //{
        //    var model = GetNonDeletedAndActive<Customer>(t => t.IsDeleted == false);
        //    return model;
        //}

        public async Task<IQueryable<Customer>> GetList()
        {
            var model = GetNonDeletedAndActive<Customer>(t => t.IsDeleted == false);
            return model;
        }

        public T Update<T>(T _object) where T : BaseEntitiy
        {
            throw new NotImplementedException();
        }
    }
}
