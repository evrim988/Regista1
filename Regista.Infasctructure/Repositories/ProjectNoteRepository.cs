using Microsoft.EntityFrameworkCore;
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
    public class ProjectNoteRepository : Repository, IProjectNoteRepository
    {
        private readonly RegistaContext registaContext;
        private readonly UnitOfWork uow;
        private readonly SessionModel session;
        public ProjectNoteRepository(RegistaContext _registaContext,SessionModel _session, UnitOfWork _uow) : base(_registaContext,_session)
        {
            this.registaContext = _registaContext;
            this.uow =_uow;
            this.session = _session;
        }

        public async Task<string> Add(int ID, string description)
        {
            var project = new ProjectNote()
            {
                Description = description
            };
            await Add(project);

            return "1";
        }

        public void Delete(int id)
        {
            var project = GetNonDeletedAndActive<ProjectNote>(t => t.ID == id);
            DeleteRange(project.ToList());

            Delete<ProjectNote>(id);
        }

      

        public async Task<IQueryable<ProjectNote>> GetList()
        {
            var model = GetNonDeletedAndActive<ProjectNote>(t => true);
            return model;
        }

      
    }
}
