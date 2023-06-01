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
    public class RequestRepository : Repository, IRequestRepository
    {
        private readonly RegistaContext context;
        private readonly UnitOfWork uow;
        private readonly SessionModel session;
        public RequestRepository(RegistaContext _context,SessionModel _session, UnitOfWork _uow) : base(_context,_session)
        {
            this.context = _context;
            this.uow = _uow;
            this.session= _session;
        }

        public async Task<string> Add(int ID, string RequestName)
        {
            var request = new Request()
            {
                RequestName = RequestName
            };
            await Add(request);

            return "1";
        }

        public void Delete(int id)
        {
            var request = GetNonDeletedAndActive<Request>(t => t.ID == id);
            DeleteRange(request.ToList());

            Delete<Request>(id);
        }

        //public Task<T> GetById<T>(int id) where T : BaseEntitiy
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IQueryable<Request>> GetList()
        {
            var model = GetNonDeletedAndActive<Request>(t => true);
            return model;
        }

        //public T Update<T>(T _object) where T : BaseEntitiy
        //{
        //    throw new NotImplementedException();
        //}
    }
}
