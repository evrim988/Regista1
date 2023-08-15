using Microsoft.EntityFrameworkCore;
using Regista.Application.Repositories;
using Regista.Domain.Dto.ResponsibleHelperModels;
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
        private readonly SessionModel session;

        public UserRepository(RegistaContext _context,SessionModel _session, IUnitOfWork _uow) : base(_context,_session)
        {
            context = _context;
            uow = _uow;
            session = _session;
        }
        public async Task<string> AddUser(User model)
        {
            try
            {
                model.CustomerID = session.CustomerID;
                await uow.repository.Add(model);
                await uow.SaveChanges();
                return "";
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<string> Update(User model)
        {
            Update(model);
            await uow.SaveChanges();
            return "";
        }
        public void Delete(int id)
        {
            var user = GetNonDeletedAndActive<User>(t => t.ID == id);
            DeleteRange(user.ToList());

            Delete<User>(id);
        }
        public async Task<IQueryable<User>> GetList()
        {
            var model = GetNonDeletedAndActive<User>(t => true);
            return model;
        }

        public async Task<List<ResponsibleDevextremeSelectListHelper>> GetResponsible()
        {
            try
            {
                List<ResponsibleDevextremeSelectListHelper> ResponsibleHelpers = new List<ResponsibleDevextremeSelectListHelper>();
                var model = context.Users
                    .Where(t => true);
                foreach (var item in model)
                {
                    ResponsibleDevextremeSelectListHelper helper = new ResponsibleDevextremeSelectListHelper()
                    {
                        ID = item.ID,
                        Name = item.Name + " " + item.Surname,
                    };
                    ResponsibleHelpers.Add(helper);
                }
                return ResponsibleHelpers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
    }
}
