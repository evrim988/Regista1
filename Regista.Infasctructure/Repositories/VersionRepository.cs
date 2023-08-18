using Regista.Application.Repositories;
using Regista.Domain.Entities;
using Regista.Domain.Enums;
using Regista.Persistance.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = Regista.Domain.Entities.Version;

namespace Regista.Infasctructure.Repositories
{
    public class VersionRepository : Repository, IVersionRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly SessionModel _session;
        private readonly RegistaContext _context;
        public VersionRepository(RegistaContext context, SessionModel session,IUnitOfWork uow) : base(context, session)
        {
            _uow = uow;
            _session = session;
            _context = context;
        }

        public async Task<string> AddVersion(Version model)
        {
            try
            {
                await _uow.repository.Add(model);
                await _uow.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteVersion(int ID)
        {
           var version = GetNonDeletedAndActive<Version>(t=>t.ID == ID);
            DeleteRange(version.ToList());
            Delete<Version>(ID);
            return "";
        }

        public async Task<IQueryable<Version>> GetList()
        {
            var model = GetNonDeletedAndActive<Version>(t => t.ObjectStatus == ObjectStatus.NonDeleted && t.Status == Status.Active);
            return model;
        }

        public async Task<string> UpdateVersion(Version model)
        {
            Update(model);
            await _uow.SaveChanges();
            return "";
        }
    }
}
