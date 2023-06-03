﻿using Regista.Application.Repositories;
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

        public async Task<string> RequestAdd(Request model)
        {
            try
            {
                await uow.repository.Add(model);
                await uow.SaveChanges();
                return "";
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async Task<string> Update(Request model)
        {
            Update(model);
            await uow.SaveChanges();
            return "";
        }
        public void Delete(int id)
        {
            var request = GetNonDeletedAndActive<Request>(t => t.ID == id);
            DeleteRange(request.ToList());

            Delete<Request>(id);
        }
        public async Task<IQueryable<Request>> GetList()
        {
            var model = GetNonDeletedAndActive<Request>(t => true);
            return model;
        }

    }
}
