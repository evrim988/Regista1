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
    public class ProjectRepository : Repository,IProjectRepository
    {
        private readonly RegistaContext context;

        private readonly IUnitOfWork uow;
        private readonly SessionModel session;
        public ProjectRepository(RegistaContext _context,SessionModel _session, IUnitOfWork _uow) : base(_context,_session)
        {
            this.context = _context;
            this.uow = _uow;
            this.session = _session;
        }
        public async Task<string> AddProject(Project model)
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

        public void Delete(int id)
        {
            var project = GetNonDeletedAndActive<Project>(t => t.ID == id);
            DeleteRange(project.ToList());

            Delete<Project>(id);
        }

        public async Task<IQueryable<Project>> GetList()
        {
            var model = GetNonDeletedAndActive<Project>(t => true);
            return model;
        }

        public T Update<T>(T _object) where T : BaseEntitiy
        {
            throw new NotImplementedException();
        }

       
    }
}
