using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Repositories
{
    public class UserRepository : Repository,IUserRepository
    {
        private readonly RegistaContext context;

        private readonly IUnitOfWork uow;

        public UserRepository(RegistaContext _context, IUnitOfWork _uow) : base(_context)
        {
            this.context = _context;
            this.uow = _uow;
        }
        public async Task<string> Add(int ID, string Name)
        {
            var user = new User()
            {
                Name = Name
            };
            await Add(user);

            return "1";
        }
        public void Delete(int id)
        {
            var user = GetNonDeletedAndActive<Customer>(t => t.id == id);
            DeleteRange(user.ToList());

            Delete<User>(id);
        }
        public async Task<IQueryable<User>> GetList()
        {
            var model = GetNonDeletedAndActive<User>(t => t.IsDeleted == true);
            return model;
        }
    }
}
